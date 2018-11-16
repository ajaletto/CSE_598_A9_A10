using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;


namespace Aletto_Doyal_A9_A10
{
   
    public partial class Login : Page
    {
        private accessType AccessType;
        private Encryption Encrypt = new Encryption();

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionObject obj = (SessionObject)Session["User"];
            AccessType = obj.Access;

            if (AccessType == accessType.Staff)
            {
                lbldbg.Text = " STAFF Access :  Session ID = " + Session.SessionID;
                btnLogin.Text = "Staff Login";
                btnCreateId.Visible = false;
            }
            else
            {
                lbldbg.Text = " Member Access :  Session ID = " + Session.SessionID;
                btnLogin.Text = "Member Login";
            }

            if (Request.Browser.Cookies && !IsPostBack)
            {
                HttpCookie hasCookie = Request.Cookies["AD_598"];
                if ((hasCookie == null) || (hasCookie["Name"] == ""))
                {
                    HttpCookie noCookie = new HttpCookie("AD_598");
                    noCookie.Values.Add("SessionId", Session.SessionID);
                    noCookie.Values.Add("username", String.Empty);
                    noCookie.Values.Add("passHash", String.Empty);
                    noCookie.Values.Add("LoggedIn", "False");
                    noCookie.Expires = DateTime.Now.AddDays(1d);
                    Response.Cookies.Add(noCookie);
                }
                else
                {
                    if(hasCookie.Values.Get("SessionId").ToString() == Session.SessionID 
                        && hasCookie.Values.Get("LoggedIn").ToString() == "True" 
                        && ValidateUserName(hasCookie.Values.Get("username").ToString(), AccessType)
                        && ValidateUserPasswrod(hasCookie.Values.Get("username").ToString(), hasCookie.Values.Get("passHash").ToString(), AccessType))
                    {
                        // move on to the main page
                        if (AccessType == accessType.Staff)
                        {
                            Response.Redirect("Staff.aspx");
                        }
                        else
                        {
                            Response.Redirect("Member.aspx");
                        }
                    }

                }
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Steps for login...
            // 1) verify the User Name
            // 2) Verify Password
            // 3) Set credentials in the Session and redirect to main page

            // validate all fields are populated
            lbldbg.Text = "";
            if (txtId.Text == "")
                lbldbg.Text = "    No User Name Entered";
            if (txtPasswd.Text == "")
                lbldbg.Text += "    No Password Entered";
            if (lbldbg.Text != "")
                return;

            // validate captcha
            if (!(lblCaptchaCorrect.Text == "Correct!"))
            {
                lbldbg.Text = "    Please validate Captcha.";
                return;
            }


            // Get User Name and  Verify
            string UserName = txtId.Text;
            bool bUserName = ValidateUserName(UserName, AccessType);
            string Hash = String.Empty;
            if (bUserName)
            {
                // get password and hash
                string Password = txtPasswd.Text;
                Hash = Encrypt.GenerateSHA256String(Password);
                bool bPasswd = ValidateUserPasswrod(UserName, Hash, AccessType);
                if (!bPasswd)
                {
                    lbldbg.Text = "INVALID PASSWORD ENTERED... Check spelling and captilization";
                    return;
                }
            }
            else
            {
                lbldbg.Text = "INVALID USER NAME ENTERED... Check spelling and captilization";
                return;
            }

            //Grab the cookie info
            HttpCookie cookie = new HttpCookie("AD_598");
            cookie.Values.Add("SessionId", Session.SessionID);
            cookie.Values.Add("username", UserName);
            cookie.Values.Add("passHash", Hash);
            cookie.Values.Add("LoggedIn", "True");
            cookie.Expires = DateTime.Now.AddHours(4);
            Response.Cookies.Add(cookie);

            // Load the session Data
            SessionObject obj = (SessionObject)Session["User"];
            obj.Name = UserName;
            obj.Hash = Hash;
            Session["User"] = obj;

            // move on to the main page
            if (AccessType == accessType.Staff)
            {
                Response.Redirect("Staff.aspx");
            }
            else
            {
                Response.Redirect("Member.aspx");
            }
        }

        protected void btnCreateId_Click(object sender, EventArgs e)
        {
            // steps for create
            // 1) Verify user name is unique (Not on the list)
            // 2) add credentials to the members xml file
            // set credentials in teh Session and redirect to Main Page
            // validate all fields are populated
            lbldbg.Text = "";
            if (txtId.Text == "")
                lbldbg.Text = "    No User Name Entered";
            if (txtPasswd.Text == "")
                lbldbg.Text += "    No Password Entered";
            if (lbldbg.Text != "")
                return;

            // validate captcha
            if (!(lblCaptchaCorrect.Text == "Correct!"))
            {
                lbldbg.Text = "    Please validate Captcha.";
                return;
            }


            if (ValidateUserName(txtId.Text, AccessType))
            {
                lbldbg.Text = "USER ID Already exists... Please enter a new User Id";
                return;
            }

            // Add to the xml file
            string xmlFileName = @"App_data\Members.xml";
            string SearchKey = @"member";
            // if access is staff, reset the file name and searchkey
            if (AccessType == accessType.Staff)
            {
                xmlFileName = @"App_data\Staff.xml";
            }
            string xmlPath = Server.MapPath("~");

            string xmlFullPath = Path.Combine(xmlPath, xmlFileName);
            string Hash = Encrypt.GenerateSHA256String(txtPasswd.Text);

            XDocument doc = XDocument.Load(xmlFullPath);
            XElement root = new XElement(SearchKey);
            root.Add(new XElement("Name", txtId.Text));
            root.Add(new XElement("PwdHash", Hash));
            doc.Element("Members").Add(root);
            doc.Save(xmlFullPath);


            //Grab the cookie info
            HttpCookie cookie = new HttpCookie("AD_598");
            cookie.Values.Add("SessionId", Session.SessionID);
            cookie.Values.Add("username", txtId.Text);
            cookie.Values.Add("passHash", Hash);
            cookie.Values.Add("LoggedIn", "True");
            cookie.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(cookie);

            // Load the session Data
            SessionObject obj = (SessionObject)Session["User"];
            obj.Name = txtId.Text;
            obj.Hash = txtPasswd.Text;
            Session["User"] = obj;

            // move on to the main page
            if (AccessType == accessType.Staff)
            {
                Response.Redirect("Staff.aspx");
            }
            else
            {
                Response.Redirect("Member.aspx");
            }
            


        }

        protected bool ValidateUserName(string userName, accessType access)
        {
            // this function returns true if User Name Exists
            bool result = false;
            string xmlFileName = @"App_data\Members.xml";
            string SearchKey = @"//Name";
            // if access is staff, reset the file name and searchkey
            if (access == accessType.Staff)
            {
                xmlFileName = @"App_data\Staff.xml";
            }
            string xmlPath = Server.MapPath("~");

            string xmlFullPath = Path.Combine(xmlPath, xmlFileName);

            try
            {
                // Open file stream 

                XPathDocument xDoc = new XPathDocument(xmlFullPath);

                var nav = xDoc.CreateNavigator();
                var nodes = nav.Evaluate(SearchKey);
                foreach (XPathNavigator node in (XPathNodeIterator)nodes)
                {
                    if (node.InnerXml == userName)
                    {
                        result = true;
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                return false; // error occured so reply with not valid.
            }

            return result;
        }

        protected bool ValidateUserPasswrod(string userName, string Password, accessType access)
        {
            // this function returns true if User Name Exists
            bool result = false;
            string xmlFileName = @"App_data\Members.xml";
            //string SearchKey = "Members";
            // if access is staff, reset the file name and searchkey
            if (access == accessType.Staff)
            {
                xmlFileName = @"App_data\Staff.xml";
               // SearchKey = "Staff";
            }
            string xmlPath = Server.MapPath("~");

            string xmlFullPath = Path.Combine(xmlPath, xmlFileName);

            try
            {
                // Open file stream 

                XPathDocument xDoc = new XPathDocument(xmlFullPath);

                var nav = xDoc.CreateNavigator();
                var nodes = nav.Evaluate(@"//member");
                foreach (XPathNavigator node in (XPathNodeIterator)nodes)
                {
                    // Check Name
                    var NameElem = node.MoveToFirstChild();
                    if (node.InnerXml == userName)
                    {               
                        node.MoveToNext();
                        if (node.InnerXml == Password)
                            return true;
                        else
                            return false;
                    }

                }
            }
            catch (Exception e)
            {
                return false; // error occured so reply with not valid.
            }

            return result;
        }

        protected void ValidateCaptchaButton_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // initialize the Captcha validation error label
                lblCaptchaCorrect.Text = "Incorrect CAPTCHA code!";
                lblCaptchaIncorrect.Visible = true;
            }




            if (IsPostBack)
            {
                // validate the Captcha to check we're not dealing with a bot
                string userInput = txtCaptcha.Text;
                bool isHuman = ExampleCaptcha.Validate(userInput);
                txtCaptcha.Text = null; // clear previous user input

                if (isHuman)
                {
                    lblCaptchaCorrect.Visible = true;
                    lblCaptchaIncorrect.Visible = false;
                    lblCaptchaCorrect.Text = "Correct!";
                }
                else
                {
                    lblCaptchaIncorrect.Visible = true;
                    lblCaptchaCorrect.Visible = false;
                    lblCaptchaIncorrect.Text = "Incorrect!";
                }
            }
        }
    }
}