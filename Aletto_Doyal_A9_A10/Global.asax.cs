using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;


// global.aspx for project.
// This file was developed by Roy Doyal
// The session object was designed and developed by Roy Doyal
// in the session we store the User Name, password hash, and Access level fo the session.


namespace Aletto_Doyal_A9_A10
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        void Session_Start(object sender, EventArgs e)
        {
            string indexKey = "User";
            SessionObject obj;
            int count = 0;

            if (Session[indexKey] == null)
            {
                obj = new SessionObject();
                Session[indexKey] = obj;
            }
            if (Session["Count"] != null)
                count = (int)Session["Count"];
            Session["Count"] = count + 1;
        }

        void Session_End(object sender, EventArgs e)
        {
            int count = (int)Session["Count"];
            Session["Count"] = count - 1;


        }
    }
}