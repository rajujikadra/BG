using System.Web;
using System.Web.Optimization;

namespace BG
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                         @"~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/sweetalert.min.js",
                      "~/Scripts/HoldOn.js",
                      "~/Scripts/ClientJS/common.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/sweetalert.min.css",
                      "~/Content/HoldOn.css"));
            bundles.Add(new StyleBundle("~/Admin/css").Include(
                "~/Areas/Admin/assets/css/app.min.css",
                "~/Areas/Admin/assets/css/style.css",
                "~/Areas/Admin/assets/css/components.css",
                "~/Areas/Admin/assets/css/custom.css",
                "~/Content/HoldOn.css",
                "~/Areas/Admin/assets/bundles/datatables/datatables.min.css",
                "~/Areas/Admin/assets/bundles/datatables/DataTables-1.10.16/css/dataTables.bootstrap4.min.css"));

            bundles.Add(new ScriptBundle("~/Admin/JS").Include(
                "~/Areas/Admin/assets/bundles/jquery-ui/jquery-ui.min.js",
                "~/Areas/Admin/assets/js/app.min.js",
                "~/Areas/Admin/assets/bundles/apexcharts/apexcharts.min.js",
                "~/Areas/Admin/assets/js/page/index.js",
                "~/Areas/Admin/assets/js/scripts.js",
                "~/Areas/Admin/assets/bundles/sweetalert/sweetalert.min.js",
                "~/Areas/Admin/assets/js/page/sweetalert.js",
                "~/Areas/Admin/assets/bundles/datatables/datatables.min.js",
                "~/Areas/Admin/assets/bundles/datatables/DataTables-1.10.16/js/dataTables.bootstrap4.min.js",
                "~/Areas/Admin/assets/js/page/datatables.js",
                "~/Areas/Admin/assets/js/scripts.js",
                 "~/Scripts/HoldOn.js",
                "~/Areas/Admin/assets/js/custom.js"));
        }
    }
}
