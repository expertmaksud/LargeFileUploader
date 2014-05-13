using System.Web;
using System.Web.Optimization;

namespace FilesDIRECT3
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                        "~/Scripts/Lib/jquery-1.7.1.js",
                                        "~/Scripts/Lib/jquery-ui-1.8.20.js",
                                        "~/Scripts/Lib/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/plupload").Include("~/Scripts/Lib/plupload.full.js"));
            bundles.Add(new ScriptBundle("~/bundles/pluploadui").Include("~/Scripts/Lib/jquery.ui.plupload.js"));

            bundles.Add(new ScriptBundle("~/bundles/filemanager").Include("~/Scripts/Custom/fileManager.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/themes/base/jquery-ui.css", "~/Content/jquery.ui.plupload.css", "~/Content/site.css"));
            
            BundleTable.EnableOptimizations = false;


        }
    }
}