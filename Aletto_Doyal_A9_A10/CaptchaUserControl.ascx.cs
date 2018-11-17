using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aletto_Doyal_A9_A10
{
    public partial class CaptchaUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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