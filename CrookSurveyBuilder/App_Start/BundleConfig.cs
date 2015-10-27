using System.Web;
using System.Web.Optimization;

namespace CrookSurveyBuilder
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.11.4.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/toastr.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/toastr.js",
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-resource.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/angular-local-storage.js",
                    "~/Scripts/angular-ui/sortable.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/surveybuilder").Include(
                //App / config
                    "~/Scripts/app/app.js",
                    "~/Scripts/app/routes.js",
                    //Services
                    "~/Scripts/app/services/SurveyService.js",
                    "~/Scripts/app/services/AuthService.js",
                    "~/Scripts/app/services/AuthInterceptorService.js",
                    "~/Scripts/app/services/SurveyResponseService.js",
                    //Controllers
                    "~/Scripts/app/controllers/IndexController.js",
                    "~/Scripts/app/controllers/RegisterController.js",
                    "~/Scripts/app/controllers/SurveysController.js",
                    "~/Scripts/app/controllers/SurveyDetailsController.js",
                    "~/Scripts/app/controllers/LoginController.js",
                    "~/Scripts/app/controllers/TakeSurveyController.js"
                ));
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
