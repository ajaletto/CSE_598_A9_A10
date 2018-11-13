using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
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

            // Get User Name and  Verify
            string UserName = txtId.Text;

            bool bUserName = ValidateUserName(UserName, AccessType);
            if (bUserName)
            {
                // get password and hash
                string Password = txtPasswd.Text;
                string Hash = Encrypt.GenerateSHA256String(Password);
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
        }

        protected void btnCreateId_Click(object sender, EventArgs e)
        {
            // steps fro create
            // 1) Verify user name is unique (Not on the list)
            // 2) add credentials to the members xml file
            // set credentials in teh Session and redirect to Main Page
        
        }

        protected bool ValidateUserName(string userName, accessType access)
        {
            // this function returns true if User Name Exists
            bool result = false;
            string xmlFileName = @"App_data\Members.xml";
            string SearchKey = "Members";
            // if access is staff, reset the file name and searchkey
            if (access == accessType.Staff)
            {
                xmlFileName = @"App_data\Staff.xml";
                SearchKey = "Staff";
            }
            string xmlPath = Server.MapPath("~");

            string xmlFullPath = Path.Combine(xmlPath, xmlFileName);

            try
            {
                // Open file stream 

                XPathDocument xDoc = new XPathDocument(xmlFullPath);

                var nav = xDoc.CreateNavigator();
                var nodes = nav.Evaluate(@"//Name");
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
            string SearchKey = "Members";
            // if access is staff, reset the file name and searchkey
            if (access == accessType.Staff)
            {
                xmlFileName = @"App_data\Staff.xml";
                SearchKey = "Staff";
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
        
    }
}