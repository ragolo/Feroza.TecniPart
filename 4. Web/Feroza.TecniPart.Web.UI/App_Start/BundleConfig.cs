// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the BundleConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI
{
    using System.Web.Optimization;

    /// <summary>The bundle config.</summary>
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862

        /// <summary>The register bundles.</summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/app/app.module.js")
                .Include(
                "~/app/blocks/logger/logger.module.js",
                    "~/app/blocks/logger/logger.js")
                .Include(
                "~/app/lazyload/lazyload.module.js",
                "~/app/lazyload/constants.js",
                "~/app/lazyload/config.js")
                .Include(
                "~/app/routes/routes.module.js",
                "~/app/routes/config.js",
                "~/app/routes/provider.js",
                "~/app/routes/routes.run.js")
                    .Include(
                "~/app/colors/colors.module.js",
                    "~/app/colors/constants.js",
                    "~/app/colors/service.js")
                .Include(
                    "~/app/core/core.module.js",
                    "~/app/core/constants.js",
                    "~/app/core/config.js",
                    "~/app/core/core.run.js")
                .Include(
                "~/app/layout/sidebar/sidebar.module.js",
                "~/app/layout/sidebar/sidebar.module.js",
                "~/app/layout/sidebar/sidebarController.js",
                "~/app/layout/sidebar/userBlockController.js",
                    "~/app/layout/sidebar/sidebarDirective.js"));
        }
    }
}