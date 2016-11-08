// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidadoresInstaller.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   The validators installer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.ResolucionDepencias.Installer
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using FluentValidation;

    using Servicios.Interfaces.Installer;

    /// <summary>The validators installer.</summary>
    public class ValidadoresInstaller : IWindsorInstaller
    {
        /// <summary>The install.</summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IValidatorFactory>().ImplementedBy<CastleWindsorValidatorFactory>().LifestylePerWebRequest());
        }
    }
}