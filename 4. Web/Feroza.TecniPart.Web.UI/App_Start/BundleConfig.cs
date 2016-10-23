// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Feroza">
//   The feroza
// </copyright>
// <summary>
//   The bundle config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI
{
    using System.Web.Optimization;

    /// <summary>The bundle config.</summary>
    public class BundleConfig
    {
        /// <summary>The register bundles.</summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Application Scripts
            bundles.Add(new ScriptBundle("~/bundles/appScripts")

                // Main module definition
                .Include("~/app/app.module.js")
                .Include("~/app/app.config.js")

                // All modules definition
                .Include("~/app/modules/core/core.module.js")
                .IncludeDirectory("~/app/modules/core", "*.js", true)
                   .Include("~/app/modules/acceso/acceso.module.js")
                .IncludeDirectory("~/app/modules/acceso", "*.js", true)
                .Include("~/app/modules/colors/colors.module.js")
                .IncludeDirectory("~/app/modules/colors", "*.js", true)
                .Include("~/app/modules/material/material.module.js")
                .IncludeDirectory("~/app/modules/material", "*.js", true)
                .Include("~/app/modules/lazyload/lazyload.module.js")
                .IncludeDirectory("~/app/modules/lazyload", "*.js", true)
                .Include("~/app/modules/loadingbar/loadingbar.module.js")
                .IncludeDirectory("~/app/modules/loadingbar", "*.js", true)
                .Include("~/app/modules/navsearch/navsearch.module.js")
                .IncludeDirectory("~/app/modules/navsearch", "*.js", true)
                .Include("~/app/modules/preloader/preloader.module.js")
                .IncludeDirectory("~/app/modules/preloader", "*.js", true)
                .Include("~/app/modules/routes/routes.module.js")
                .IncludeDirectory("~/app/modules/routes", "*.js", true)
                .Include("~/app/modules/settings/settings.module.js")
                .IncludeDirectory("~/app/modules/settings", "*.js", true)
                .Include("~/app/modules/sidebar/sidebar.module.js")
                .IncludeDirectory("~/app/modules/sidebar", "*.js", true)
                .Include("~/app/modules/translate/translate.module.js")
                .IncludeDirectory("~/app/modules/translate", "*.js", true)
                .Include("~/app/modules/utils/utils.module.js")
                .IncludeDirectory("~/app/modules/utils", "*.js", true)

                // Custom scripts
                //.Include("~/app/custom/tecnipart/login.module.js")
                //.IncludeDirectory("~/app/custom/login", "*.js", true)

                .Include("~/app/custom/tecnipart/tecnipart.module.js")
                .Include("~/app/custom/tecnipart/tecnipart.run.js")
                .Include("~/app/custom/tecnipart/utils/utils.module.js")
                .IncludeDirectory("~/app/custom/tecnipart/utils", "*.js", true)
                .IncludeDirectory("~/app/custom/tecnipart/blocks", "*.module.js", true)
                .IncludeDirectory("~/app/custom/tecnipart/blocks", "*.js", true)
                .IncludeDirectory("~/app/custom/tecnipart", "*.js", true));

            // Base Scripts (not lazyloaded)
            bundles.Add(new ScriptBundle("~/bundles/baseScripts").Include(
              "~/Scripts/Vendor/modernizr/modernizr.js",
              "~/Scripts/Vendor/jquery/dist/jquery.js",
              "~/Scripts/Vendor/angular/angular.js",
              "~/Scripts/Vendor/angular-route/angular-route.js",
              "~/Scripts/Vendor/angular-cookies/angular-cookies.js",
              "~/Scripts/Vendor/angular-animate/angular-animate.js",
              "~/Scripts/Vendor/angular-touch/angular-touch.js",
              "~/Scripts/Vendor/restangular/lodash.min.js",
              "~/Scripts/Vendor/restangular/restangular.min.js",
              "~/Scripts/Vendor/angular-ui-router/release/angular-ui-router.js",
              "~/Scripts/Vendor/ngstorage/ngStorage.js",
              "~/Scripts/Vendor/angular-ui-utils/ui-utils.js",
              "~/Scripts/Vendor/angular-ui-utils/index.js",
              "~/Scripts/Vendor/angular-ui-mask/dist/mask.js",
              "~/Scripts/Vendor/angular-ui-event/dist/event.js",
              "~/Scripts/Vendor/angular-ui-validate/dist/validate.js",
              "~/Scripts/Vendor/angular-ui-indeterminate/dist/indeterminate.js",
              "~/Scripts/Vendor/angular-ui-scrollpoint/dist/scrollpoint.js",
              "~/Scripts/Vendor/angular-ui-scroll/dist/ui-scroll.js",
              "~/Scripts/Vendor/angular-ui-uploader/dist/uploader.js",
              "~/Scripts/Vendor/angularjs-toaster/angular-toastr.tpls.min.js",
              "~/Scripts/Vendor/angular-sanitize/angular-sanitize.js",
              "~/Scripts/Vendor/angular-resource/angular-resource.js",
              "~/Scripts/Vendor/angular-translate/angular-translate.js",
              "~/Scripts/Vendor/angular-translate-loader-url/angular-translate-loader-url.js",
              "~/Scripts/Vendor/angular-translate-loader-static-files/angular-translate-loader-static-files.js",
              "~/Scripts/Vendor/angular-translate-storage-local/angular-translate-storage-local.js",
              "~/Scripts/Vendor/angular-translate-storage-cookie/angular-translate-storage-cookie.js",
              "~/Scripts/Vendor/oclazyload/dist/ocLazyLoad.js",
              "~/Scripts/Vendor/angular-bootstrap/ui-bootstrap-tpls.js",
              "~/Scripts/Vendor/angular-strap/angular-strap.min.js",
              "~/Scripts/Vendor/angular-strap/angular-strap.tpl.min.js",
              "~/Scripts/Vendor/angular-loading-bar/build/loading-bar.js",
                "~/Scripts/Vendor/jquery.browser/dist/jquery.browser.js",
                   "~/Scripts/Vendor/angular-material/angular-aria.js",
                   "~/Scripts/Vendor/angular-messages/angular-messages.min.js",
                   "~/Scripts/Vendor/md-data-table/md-data-table.min.js",
                   "~/Scripts/Vendor/angular-local-storage/angular-local-storage.min.js"
                   ));

            bundles.Add(
                new ScriptBundle("~/bundles/materialScripts").Include(
                    "~/Scripts/Vendor/angular-material/angular-material.js"));

            bundles.Add(new StyleBundle("~/bundles/appStyles")
                    .Include("~/Content/app/app.css")
                    .Include("~/Content/mvc-override.css"));

            bundles.Add(new StyleBundle("~/bundles/bootstrapStyles")
                    .Include("~/Content/app/bootstrap.css"));

            bundles.Add(new StyleBundle("~/bundles/materialStyles")
                    .Include("~/Scripts/Vendor/angular-material/angular-material.css")
                .Include("~/Scripts/Vendor/md-data-table/md-data-table.css"));
        }
    }
}