using System.Diagnostics;
using System.Web;
using System.Web.Optimization;

namespace EmployeeRegistration.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/node_modules/jquery/dist/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/node_modules/jquery-ui-dist/jquery-ui.min.js"));
            bundles.Add(new StyleBundle("~/bundles/themes").Include("~/node_modules/jquery-ui-dist/jquery-ui.min.css",
                                                                    "~/node_modules/jquery-ui-dist/jquery-ui.theme.min.css"));
            bundles.Add(new StyleBundle("~/bundles/callogo").Include("~/node_modules/font-awesome/css/font-awesome.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/sumoselectjs").Include("~/node_modules/sumoselect/jquery.sumoselect.min.js"));
            bundles.Add(new StyleBundle("~/bundles/sumoselectcss").Include("~/node_modules/sumoselect/sumoselect.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatablejs").Include("~/node_modules/datatables/media/js/jquery.dataTables.min.js"));
            bundles.Add(new StyleBundle("~/bundles/datatablecss").Include("~/node_modules/datatables/media/css/jquery.dataTables.min.css"));

            //bundles.Add(new ScriptBundle("~/bundles/multijs").Include("~/node_modules/bootstrap-multiselect/dist/js/bootstrap-multiselect.js"));
            //bundles.Add(new StyleBundle("~/bundles/multicss").Include("~/node_modules/bootstrap-multiselect/dist/css/bootstrap-multiselect.css"));
            //bundles.Add(new Bundle("~/bundles/bootstrap").Include("~/node_modules/bootstrap/dist/js/bootstrap.min.js"));
            //Debug.WriteLine("Bundle configured successfully.");
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/node_modules/jquery/dist/jquery.js")
            //                                          .IncludeDirectory("~/node_modules/jquery/dist","*.js"));
            //// jQuery UI
            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/node_modules/jquery-ui/dist/jquery-ui.js")
            //    .IncludeDirectory("~/node_modules/jquery-ui/dist","*.js"));

            ////bundles.Add(new ScriptBundle("~/bundles/jquery-migrate").Include(
            ////"~/node_modules/jquery-migrate/dist/jquery-migrate.js"));
            //// jQuery UI (CSS)
            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/node_modules/jquery-ui-css/jquery-ui.css", "~/node_modules/jquery-ui-css/jquery-ui.theme.css")
            //    .IncludeDirectory("~/node_modules/jquery-ui-css","*.css"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/node_modules/font-awesome/css/font-awesome.css"));
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap-multiselect").Include("~/node_modules/bootstrap-multiselect/dist/js/bootstrap-multiselect.min.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}