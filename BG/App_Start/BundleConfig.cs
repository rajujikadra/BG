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
                      "~/Scripts/HoldOn.js",
                      "~/Scripts/ClientJS/common.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/HoldOn.css"));
            bundles.Add(new StyleBundle("~/Admin/css").Include(
                     //Bootstrap
                     "~/Areas/Admin/vendors/bootstrap/dist/css/bootstrap.min.css",
                     //Font Awesome
                     "~/Areas/Admin/vendors/font-awesome/css/font-awesome.min.css",
                     //NProgress
                     "~/Areas/Admin/vendors/nprogress/nprogress.css",
                     //iCheck
                     "~/Areas/Admin/vendors/iCheck/skins/flat/green.css",
                     //bootstrap-progressbar
                     "~/Areas/Admin/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                     //JQVMap
                     "~/Areas/Admin/vendors/jqvmap/dist/jqvmap.min.css",
                     //bootstrap-daterangepicker
                     "~/Areas/Admin/vendors/bootstrap-daterangepicker/daterangepicker.css",
                     //Custom Theme Style
                     "~/Areas/Admin/build/css/custom.min.css"));

            bundles.Add(new ScriptBundle("~/Admin/JS").Include(
                      //jQuery
                      "~/Areas/Admin/vendors/jquery/dist/jquery.min.js",
                      //Bootstrap
                      "~/Areas/Admin/vendors/bootstrap/dist/js/bootstrap.bundle.min.js",
                      //FastClick
                      "~/Areas/Admin/vendors/fastclick/lib/fastclick.js",
                      //NProgress
                      "~/Areas/Admin/vendors/nprogress/nprogress.js",
                      //Chart.js
                      "~/Areas/Admin/vendors/Chart.js/dist/Chart.min.js",
                      //gauge.js
                      "~/Areas/Admin/vendors/gauge.js/dist/gauge.min.js",
                      //bootstrap-progressbar
                      "~/Areas/Admin/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                      //iCheck
                      "~/Areas/Admin/vendors/iCheck/icheck.min.js",
                      //Skycons
                      "~/Areas/Admin/vendors/skycons/skycons.js",
                      //Flot
                      "~/Areas/Admin/vendors/Flot/jquery.flot.js",
                      "~/Areas/Admin/vendors/Flot/jquery.flot.pie.js",
                      "~/Areas/Admin/vendors/Flot/jquery.flot.time.js",
                      "~/Areas/Admin/vendors/Flot/jquery.flot.stack.js",
                      "~/Areas/Admin/vendors/Flot/jquery.flot.resize.js",
                      //Flot plugins
                      "~/Areas/Admin/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                      "~/Areas/Admin/vendors/flot-spline/js/jquery.flot.spline.min.js",
                      "~/Areas/Admin/vendors/flot.curvedlines/curvedLines.js",
                      //DateJS
                      "~/Areas/Admin/vendors/DateJS/build/date.js",
                      //JQVMap
                      "~/Areas/Admin/vendors/jqvmap/dist/jquery.vmap.js",
                      "~/Areas/Admin/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                      "~/Areas/Admin/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                      //bootstrap-daterangepicker
                      "~/Areas/Admin/vendors/moment/min/moment.min.js",
                      "~/Areas/Admin/vendors/bootstrap-daterangepicker/daterangepicker.js",
                      //Custom Theme Scripts
                      "~/Areas/Admin/build/js/custom.min.js"));
        }
    }
}
