using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


// Roy's Tryit page for the DLL, Global.aspx, and XML function
// This page was developed by Roy Doyal.

namespace Aletto_Doyal_A9_A10
{
    public partial class Roy_A9_TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSessionID.Text = Session.SessionID;
            lblUser.Text = (string)Session["TryIt"].ToString();
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
            //while( !done )
            {
                sResult = doc.ToString();
                txtXMLResult.Text = sResult;
            }
        }
    }
}