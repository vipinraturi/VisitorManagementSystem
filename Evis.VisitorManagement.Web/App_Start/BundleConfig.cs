using System.Web;
using System.Web.Optimization;


namespace Evis.VisitorManagement.Web
{

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/customCss").Include(
                    "~/Content/assets/bootsrtap/css/bootstrap-theme.css",
                    "~/Content/assets/bootsrtap/css/bootstrap.css",
                    "~/Content/assets/css/form-elements.css",
                    "~/Content/assets/css/style.css",
                    "~/Content/assets/font-awesome/css/font-awesome.css",
                    "~/Content/assets/ico/favicon.png",
                    "~/Content/assets/ico/apple-touch-icon-144-precomposed.png",
                    "~/Content/assets/ico/apple-touch-icon-114-precomposed.png",
                    "~/Content/assets/ico/apple-touch-icon-72-precomposed.png",
                    "~/Content/assets/ico/apple-touch-icon-57-precomposed.png"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/assets/js/jquery-1.11.1.min.js",
                      "~/Content/assets/bootstrap/js/bootstrap.js",
                      "~/Content/assets/js/jquery.backstretch.js",
                      "~/Content/assets/js/scripts.js"));
        }
    }
}