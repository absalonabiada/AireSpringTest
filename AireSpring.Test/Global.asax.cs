using AireSpring.Test.App_Start;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AireSpring.Test
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["Name"] = "AireSpring Test";
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session[Vars.ConnectionStringName] = ConfigurationManager.ConnectionStrings[Vars.ConnectionStringName].ConnectionString;
        }
    }
}