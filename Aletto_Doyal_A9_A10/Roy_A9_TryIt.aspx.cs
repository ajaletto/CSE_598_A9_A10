using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Aletto_Doyal_A9_A10
{
    public partial class Roy_A9_TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSessionID.Text = Session.SessionID;
            SessionObject obj = (SessionObject)Session["User"];
            if (obj.Access == accessType.Member)
                lblAccess.Text = "Member";
            else
                lblAccess.Text = "Staff";
            lblUser.Text = obj.Name;
            lblPasswd.Text = obj.Hash;
        }

        protected void btnTestDll_Click(object sender, EventArgs e)
        {
            Encryption Encrtyp = new Encryption();
            txtDllResult.Text =  Encrtyp.GenerateSHA256String(txtDllInput.Text);
        }

        protected void btnXMLTest_Click(object sender, EventArgs e)
        {
            string xmlFileName = @"App_data\TryIt.xml";
            string SearchKey = @"TestStrings";
            string xmlPath = Server.MapPath("~");

            string xmlFullPath = Path.Combine(xmlPath, xmlFileName);

            XDocument doc = XDocument.Load(xmlFullPath);
            XElement root = new XElement(SearchKey);
            root.Add(new XElement("Tests", txtXMLData.Text));
            doc.Element("TryIt").Add(root);
            doc.Save(xmlFullPath);

            // read and display

            doc = XDocument.Load(xmlFullPath);
            bool done = false;
            string sResult = null;
            while( !done )
            {
                
            }
        }
    }
}