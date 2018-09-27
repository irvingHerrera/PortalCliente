using System.Web;
using System.Web.Optimization;

namespace PortalCliente.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugin").Include(
                      "~/Scripts/plugin/datepicker.js",
                      "~/Scripts/plugin/jquery.tablesorter.min.js",
                      "~/Scripts/plugin/select2.min.js",
                      "~/Scripts/plugin/angular.min.js",
                      "~/Scripts/plugin/angular-sanitize.min.js",
                      "~/Scripts/plugin/select.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/app/site.js",
                      "~/Scripts/app/layout/code.js",
                      "~/Scripts/app/layout/menu.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/app/css").Include(
                      "~/Content/app/site.css"));

            bundles.Add(new StyleBundle("~/Content/layout/css").Include(
                      "~/Content/app/layout/acordeon3.css",
                      "~/Content/app/layout/grid.css",
                      "~/Content/app/layout/menu.css",
                      "~/Content/app/layout/styles.css"));

            bundles.Add(new StyleBundle("~/Content/plugin/css").Include(
                      "~/Content/plugin/fontawesome-all.min.css",
                      "~/Content/plugin/select2.min.css",
                      "~/Content/plugin/select.css"));
        }
    }
}
