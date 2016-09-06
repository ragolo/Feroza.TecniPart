// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the MvcApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using Infraestructura.ResolucionDepencias;

    using Windsor;

    /// <summary>
    /// The mvc application.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// The container.
        /// </summary>
        private static IWindsorContainer container;

        /// <summary>
        /// The configure windsor.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            container = new WindsorContainer();
            container.Install(FromAssembly.This(), new ModuloRepositorios());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;
        }

        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ConfigureWindsor(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, container));
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
