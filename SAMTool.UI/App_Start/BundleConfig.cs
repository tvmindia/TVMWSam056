using System.Web.Optimization;

namespace SAMTool.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*Style Sheet here*/
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/bootstrap-theme.css", "~/Content/font-awesome.min.css", "~/Content/Custom.css", "~/Content/sweetalert.css", "~/Content/Custom.css", "~/Content/sweetalert.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrapdatepicker").Include("~/Content/bootstrap-datepicker3.min.css"));         
            bundles.Add(new StyleBundle("~/Content/DataTables/css/datatable").Include("~/Content/DataTables/css/dataTables.bootstrap.min.css", "~/Content/DataTables/css/responsive.bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/UserCSS/Login").Include("~/Content/UserCSS/Login.css"));
            /*Scripts here*/
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-3.1.1.min.js")); 
            bundles.Add(new ScriptBundle("~/bundles/jqueryform").Include("~/Scripts/jquery.form.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrusiveajaxvalidate").Include("~/Scripts/jquery.validate.min.js", "~/Scripts/jquery.validate.unobtrusive.min.js", "~/Scripts/jquery.unobtrusive-ajax.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include("~/Scripts/DataTables/jquery.dataTables.min.js", "~/Scripts/DataTables/dataTables.bootstrap.min.js", "~/Scripts/DataTables/dataTables.responsive.min.js", "~/Scripts/DataTables/responsive.bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/userpluginjs").Include("~/Scripts/jquery.noty.packaged.min.js", "~/Scripts/custom.js", "~/Scripts/sweetalert.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/User").Include("~/Scripts/CustomJs/User.js"));
            bundles.Add(new ScriptBundle("~/bundles/AppObject").Include("~/Scripts/CustomJs/AppObject.js"));
            bundles.Add(new ScriptBundle("~/bundles/Application").Include("~/Scripts/CustomJs/Application.js"));
            bundles.Add(new ScriptBundle("~/bundles/Roles").Include("~/Scripts/CustomJs/Roles.js"));





        }
    }
}