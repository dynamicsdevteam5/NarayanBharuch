using System.Web;
using System.Web.Optimization;

namespace NarayanBharuch
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Areas/Admin/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Areas/Admin/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Areas/Admin/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Areas/Admin/Scripts/bootstrap.js",
                      "~/Areas/Admin/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Areas/Admin/Content/css").Include(
                      "~/Areas/Admin/Content/bootstrap.css",
                      "~/Areas/Admin/Content/site.css"));
        }
    }
}
