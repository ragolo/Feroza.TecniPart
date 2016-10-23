// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the WebApiApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Castle.Windsor.Installer;

    using Infraestructura.ResolucionDepencias.Installer;

    using Windsor;

    /// <summary>The web api application.</summary>
    public class Global : HttpApplication
    {
        /// <summary>The configure windsor.</summary>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            var container = Ragolo.Core.IoC.IocHelper.Instance;
            container.Install(new ValidadoresInstaller());
            container.Install(FromAssembly.This(), new ModuloRepositorios());
            var dependencyResolver = new WindsorDependencyResolver(container.GetContainer());
            configuration.DependencyResolver = dependencyResolver;
        }

        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ConfigureWindsor(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, Ragolo.Core.IoC.IocHelper.Instance.GetContainer()));
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}