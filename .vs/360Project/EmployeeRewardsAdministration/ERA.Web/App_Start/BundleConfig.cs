using System.Web;
using System.Web.Optimization;

namespace ERA.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string kendouiVersion = "2020.2.617";
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/bundles/kendostyles").Include(
               string.Format("~/Content/kendo/{0}/kendo.common.min.css", kendouiVersion),
                string.Format("~/Content/kendo/{0}/kendo.mobile.all.min.css", kendouiVersion),
                string.Format("~/Content/kendo/{0}/kendo.silver.min.css", kendouiVersion)));

            bundles.Add(new StyleBundle("~/bundles/quickapp/kendostyles").Include(
               string.Format("~/Content/kendo/{0}/kendo.common.min.css", kendouiVersion),
                string.Format("~/Content/kendo/{0}/kendo.mobile.all.min.css", kendouiVersion),
                string.Format("~/Content/kendo/{0}/kendo.material-v2.min.css", kendouiVersion)));


            bundles.Add(new ScriptBundle("~/bundles/kendoscripts").Include(
                       string.Format("~/Scripts/kendo/{0}/jquery.min.js", kendouiVersion),
                       string.Format("~/Scripts/kendo/{0}/jszip.min.js", kendouiVersion),
                       string.Format("~/Scripts/kendo/{0}/kendo.all.min.js", kendouiVersion),
                       string.Format("~/Scripts/kendo/{0}/kendo.aspnetmvc.min.js", kendouiVersion),
                       string.Format("~/Scripts/kendo/{0}/pako_deflate.min.js", kendouiVersion)));
        }
    }
}
