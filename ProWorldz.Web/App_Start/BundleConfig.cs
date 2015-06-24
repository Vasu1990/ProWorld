using System.Web;
using System.Web.Optimization;

namespace ProWorldz.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/loginScripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/ProWorldz.login.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));


            //************************************NOTE**********************************************//
            //if BundleTable.EnableOptimizations = false it will look for unminified files 
            //since we do not have un minified files for these css it cannnot be used as bundle in dev mode

            //css was trying to find image by ../ ,in the case of ~/Content/themes/loginstyles 
            //it was looking fo the image in Content/themes folder so I gave relative path for image as bundle name
            bundles.Add(new StyleBundle("~/Content/themes/social-3/login/loginstyles").Include(
                        "~/Content/themes/social-3/css/theme-core.min.css",
                        "~/Content/themes/social-3/css/module-layout.min.css",
                        "~/Content/themes/custom/Proworldz.login.css"));
            

            //Unless EnableOptimizations is true or
            // the debug attribute in the compilation Element  in the Web.config file is set to false,
            //files will not be bundled or minified.
            BundleTable.EnableOptimizations = false ;
        }
    }
}