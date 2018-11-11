using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aletto_Doyal_A9_A10
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionObject obj = (SessionObject)Session["User"];
            if (obj.Access == accessType.Staff)
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
    }
}