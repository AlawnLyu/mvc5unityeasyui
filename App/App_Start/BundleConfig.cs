using System.Web;
using System.Web.Optimization;

namespace App
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //jqueryform
            bundles.Add(new ScriptBundle("~/bundles/jquryform").Include(
                "~/Scripts/jquery.form.js"));

            //jqueryval
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js", 
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            //easyui
            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
            "~/Scripts/jquery.easyui-{version}.js", 
            "~/Scripts/app/jquery.easyui.plus.js"));

            bundles.Add(new StyleBundle("~/Content/themes/bootstrap/css").Include(
                "~/Content/themes/bootstrap/easyui.css"));
            bundles.Add(new StyleBundle("~/Content/themes/gray/css").Include(
                "~/Content/themes/gray/easyui.css"));
            bundles.Add(new StyleBundle("~/Content/themes/metro/css").Include(
                "~/Content/themes/metro/easyui.css"));
            bundles.Add(new StyleBundle("~/Content/themes/default/css").Include(
                "~/Content/themes/default/easyui.css"));

            //wdtree
            bundles.Add(new StyleBundle("~/bundles/wdtree").Include(
                "~/Scripts/jquery.tree.js"));

            bundles.Add(new StyleBundle("~/Content/wdtree").Include(
                "~/Content/tree/css/tree.css"));

            //customcss
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css"));

            //customscript
            bundles.Add(new StyleBundle("~/bundles/home").Include(
                "~/Scripts/app/home.js"));
        }
    }
}
