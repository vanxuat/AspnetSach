using System.Web;
using System.Web.Optimization;

namespace websach
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.UseCdn = true;

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/css/suly.css"));
            bundles.Add(new ScriptBundle("~/vanxuat/js").Include("~/Scripts/suly.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery", "https://code.jquery.com/jquery-3.2.1.slim.min.js").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap", "https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css", "https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css").Include("~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/Jqa").Include("~/Scripts/jquery-3.4.1.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/confirm", "https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/confirmcss", "https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.css"));


            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;
        }
    }
}
