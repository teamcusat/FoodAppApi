using System.Web;
using System.Web.Optimization;

namespace FoodApp.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/SoCXOWeb").Include("~/Scripts/socxo-web.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/morrischart").Include("~/Scripts/raphael.js", "~/Scripts/morris.js"));

            bundles.Add(new ScriptBundle("~/bundles/LineControl").Include("~/Scripts/editor.js"));

            bundles.Add(new ScriptBundle("~/bundles/Switcher").Include("~/Scripts/switcher.js"));

            bundles.Add(new ScriptBundle("~/bundles/easypiechart").Include("~/Scripts/easypiechart.js"));



            bundles.Add(
                new ScriptBundle("~/bundles/pixeladmin").Include(
                    "~/Scripts/pixeladmin/bootstrap.js",
                    "~/Scripts/pixeladmin/pixel-admin.js",
                    "~/Scripts/bootbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/Schedule").Include("~/Scripts/schedule.js"));

            bundles.Add(new ScriptBundle("~/bundles/SoCXOLogin").Include("~/Scripts/socxo-login.js"));

            bundles.Add(new ScriptBundle("~/bundles/StartPixelAdmin").Include("~/Scripts/start-pixeladmin.js"));

            bundles.Add(new ScriptBundle("~/bundles/SoCXOFreemium").Include("~/Scripts/socxo-freemium.js"));


            bundles.Add(
                new StyleBundle("~/Content/PixelAdmin").Include(
                    "~/Content/Themes/PixelAdmin/stylesheets/bootstrap.css",
                    "~/Content/Themes/PixelAdmin/stylesheets/pixel-admin.css",
                    "~/Content/Themes/PixelAdmin/stylesheets/widgets.css",
                    "~/Content/Themes/PixelAdmin/stylesheets/rtl.css",
                    "~/Content/Themes/PixelAdmin/stylesheets/themes.css",
                    "~/Content/Themes/PixelAdmin/stylesheets/pages.css",
                    "~/Content/Themes/PixelAdmin/stylesheets/site.css",
                    "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/easypiechart").Include("~/Content/easypiechart.css"));


            bundles.Add(new StyleBundle("~/Content/datepicker").Include("~/Content/datepicker3.css"));

            bundles.Add(new StyleBundle("~/Content/LineControl").Include("~/Content/editor.css"));

            bundles.Add(
                new StyleBundle("~/Content/sitesupport").Include(
                    "~/Content/Themes/PixelAdmin/stylesheets/sitesupport.css"));
        }

    }
}