// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiControllersInstaller.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ApiControllersInstaller type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Windsor.Installers
{
    using System.Web.Http;

    using Castle.MicroKernel.Registration;

    using FluentValidation;

    /// <summary>
    /// The api controllers installer.
    /// </summary>
    public class ApiControllersInstaller : IWindsorInstaller
    {
        /// <summary>The install.</summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The store.</param>
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
             .BasedOn<ApiController>()
              .WithServiceSelf()
             .LifestylePerWebRequest());

            container.Register(
              Classes.FromThisAssembly()
              .BasedOn(typeof(AbstractValidator<>))
              .WithServiceFirstInterface()
              .LifestyleTransient());
        }
    }
}