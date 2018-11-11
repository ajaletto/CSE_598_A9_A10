using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BotDetect.Web.Mvc;

namespace Aletto_Doyal_A9_A10
{
    public partial class Aletto_A9_TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie myCookies = Request.Cookies["alettoTryIt"];
                if ((myCookies == null) || (myCookies["Name"] == ""))
                {
                    lblCookieTryit.Text = "Welcome, try it page tester. Enter your username into the text box and press the " +
                        "\"Add\" button to save the entered information in your cookie.";
                }
                else
                {
                    lblCookieTryit.Text = "Welcome, " + myCookies.Values.Get("id").ToString() + ". Enter your new username into the text box" +
                        " and press the \"Add\" button to change your username to the entered information in your cookie. Otherwise, " +
                        "press the \"Delete\" button to delete your cookie and start over.";
                }
            }
            else
            {
                lblCookieTryit.Text = "Your browser does not support cookies and this test will not work.";
            }
        }

        protected void btnCookieTryitAdd_Click(object sender, EventArgs e)
        {
            if (CaptchaCorrectLabel.Text == "Correct!")
            {
                HttpCookie myCookies = new HttpCookie("alettoTryIt");
                if (String.IsNullOrWhiteSpace(txtbxCookieTryitInput.Text))
                {
                    lblCookieTryItWarning.Text = "You must input your username!";
                }
                else
                {
                    //myCookies["Value"] = txtbxCookieTryitInput.Text.ToString();
                    myCookies.Values.Add("id", txtbxCookieTryitInput.Text);
                    myCookies.Expires = DateTime.Now.AddDays(30d);
                    //myCookies.Domain = "Cookie Try It";
                    Response.Cookies.Add(myCookies);
                    lblCookieTryItWarning.Text = String.Empty;
                    txtbxCookieTryitInput.Text = String.Empty;
                    lblCookieTryit.Text = "Your username for this try it page (and only this try it page) has been successfully set to \"" +
                        myCookies.Values.Get("id").ToString() + "\". Enter your new username into the text box" +
                        " and press the \"Add\" button to change your username to the entered information in your cookie. Otherwise, " +
                        "press the \"Delete\" button to delete your cookie and start over.";
                }
            }
            else
            {
                lblCookieTryItWarning.Text = "Please validate before proceeding.";
            }
        }

        protected void btnCookieTryitDelete_Click(object sender, EventArgs e)
        {
            if (CaptchaCorrectLabel.Text == "Correct!")
            {
                HttpCookie myCookie = Request.Cookies["alettoTryIt"];
                if ((myCookie == null) || (myCookie["Name"] == ""))
                {
                    lblCookieTryItWarning.Text = "You don't have any cookies for this Try It page!";
                }
                else
                {
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                    lblCookieTryItWarning.Text = String.Empty;
                    lblCookieTryit.Text = "Your username for this try it page (and only this try it page) has been successfully deleted. " +
                        "Enter your new username into the text box and press the \"Add\" button to reset your username.";
                }
            }
            else
            {
                lblCookieTryItWarning.Text = "Please validate before proceeding.";
            }
        }

        protected void ValidateCaptchaButton_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // initialize the Captcha validation error label
                CaptchaIncorrectLabel.Text = "Incorrect CAPTCHA code!";
                CaptchaIncorrectLabel.Visible = true;
            }




            if (IsPostBack)
            {
                // validate the Captcha to check we're not dealing with a bot
                string userInput = CaptchaCodeTextBox.Text;
                bool isHuman = ExampleCaptcha.Validate(userInput);
                CaptchaCodeTextBox.Text = null; // clear previous user input

                if (isHuman)
                {
                    CaptchaCorrectLabel.Visible = true;
                    CaptchaIncorrectLabel.Visible = false;
                    CaptchaCorrectLabel.Text = "Correct!";
                }
                else
                {
                    CaptchaIncorrectLabel.Visible = true;
                    CaptchaCorrectLabel.Visible = false;
                    CaptchaIncorrectLabel.Text = "Incorrect!";
                }
            }
        }
    }
}