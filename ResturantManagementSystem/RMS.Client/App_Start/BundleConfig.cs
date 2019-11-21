using System.Web;
using System.Web.Optimization;

namespace RMS.Client
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/dist/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui/jquery-ui.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                                  "~/Scripts/adminlte.js"));
            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
                                  "~/Scripts/jquery-slimscroll/jquery.slimscroll.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/fastclick").Include(
                                  "~/Scripts/fastclick/lib/fastclick.js"));
            bundles.Add(new ScriptBundle("~/bundles/demo").Include(
                                  "~/Scripts/demo.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/dist/css/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/AdminLte").Include(
                "~/Content/AdminLTE.min.css"));
            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
                "~/Content/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/ionicons").Include(
                "~/Content/ionicons.css"));
            bundles.Add(new StyleBundle("~/Content/allskin").Include(
                "~/Content/_all-skins.min.css"));
        }
    }
}
