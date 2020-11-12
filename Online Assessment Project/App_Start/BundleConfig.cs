using System.Web.Optimization;

namespace Online_Assessment_Project.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap").Include("~/Scripts/jquery-3.5.1.js", "~/Scripts/popper.js","~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Styles/Bootstrap").Include("~/Content/bootstrap.css", "~/Content/Site.css"));
            bundles.Add(new ScriptBundle("~/Scripts/ClientSideValidationScripts").Include("~/Scripts/jquery.validate.js", "~/Scripts/jquery.validate.unobtrusive.js"));
            BundleTable.EnableOptimizations = true;
        }
    }
}