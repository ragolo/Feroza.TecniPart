// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   The web api config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    using Castle.Windsor;

    using Feroza.TecniPart.Web.UI.Windsor;

    /// <summary>
    /// The web api config.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <param name="container">
        /// The container.
        /// </param>
        public static void Register(HttpConfiguration config, IWindsorContainer container)
        {
            MapRoutes(config);
            RegisterControllerActivator(container);
        }

        /// <summary>
        /// The map routes.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        private static void MapRoutes(HttpConfiguration config)
        {
            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        /// <summary>
        /// The register controller activator.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        private static void RegisterControllerActivator(IWindsorContainer container)
        {
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(container));
        }
    }
}