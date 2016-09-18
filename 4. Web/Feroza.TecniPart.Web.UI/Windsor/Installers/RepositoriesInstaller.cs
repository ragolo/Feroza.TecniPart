// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoriesInstaller.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the RepositoriesInstaller type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Windsor.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Dominio.Interfaces.Administracion;
    using Servicios.Interfaces.Administracion;

    /// <summary>
    /// The repositories installer.
    /// </summary>
    public class RepositoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// The install.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="store">
        /// The store.
        /// </param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
            Component.For<IEstadoMaestrasServicio>().ImplementedBy<EstadoMaestrasServicios>().LifestyleSingleton(),
                Component.For<IPaisServicio>().ImplementedBy<PaisServicios>().LifestyleSingleton());
        }
    }
}