using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aletto_Doyal_A9_A10
{

    // Class for sessions objects
    public enum accessType
    {
        Member, Staff
    }
    public class SessionObject
    {

        public SessionObject(string name, string hash, accessType access)
        {
            Name = name;
            Hash = hash;
            Access = access;

        }
        public SessionObject()
        {
            Name = null;
            Hash = null;
            Access = accessType.Member;
        }
        public string Name { get; set; }
        public string Hash { get; set; }
        public accessType Access { get; set; }
    }
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblDebug.Text = Session.SessionID;
        }

        protected void brnStaff_Click(object sender, EventArgs e)
        {
            lblDebug.Text = Session.SessionID;
            // Set the object stat to staff
            SessionObject obj = (SessionObject)Session["User"];
            obj.Access = accessType.Staff;
            Session["User"] = obj;
            Response.Redirect("Login.aspx");

        }

        protected void btnMember_Click(object sender, EventArgs e)
        {
            lblDebug.Text = Session.SessionID;
            // Set the object stat to staff
            SessionObject obj = (SessionObject)Session["User"];
            obj.Access = accessType.Member;
            Session["User"] = obj;
            Response.Redirect("Login.aspx");
        }
    }
}
