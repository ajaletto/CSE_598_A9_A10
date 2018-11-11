﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

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
            if (Session[indexKey] == null)
            {
                obj = new SessionObject();
                Session[indexKey] = obj;
            }
        }

        void Session_End(object sender, EventArgs e)
        {
            int count = (int)Session["Count"];
            Session["Count"] = count - 1;


        }
    }
}