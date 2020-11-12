using Online_Assessment_Project.App_Start;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace Online_Assessment_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
