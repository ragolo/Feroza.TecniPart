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
    using Api.Facade;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Dominio.Entidades.Modelos;
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
            Component.For<IEstadoMaestrasServicio>().ImplementedBy<EstadoMaestrasServicios>().LifestylePerWebRequest(),
            Component.For<IFabricantesServicio>().ImplementedBy<FabricantesServicios>().LifestylePerWebRequest(),
            Component.For<IMarcasServicio>().ImplementedBy<MarcasServicios>().LifestylePerWebRequest(),
            Component.For<IVehiculosServicio>().ImplementedBy<VehiculosServicios>().LifestylePerWebRequest(),
            Component.For<IPaisServicio>().ImplementedBy<PaisServicios>().LifestylePerWebRequest(),
            Component.For<IManagementImageFacade<Fabricantes>>()
                .ImplementedBy<ManagementImageFacade<Fabricantes>>()
                .LifestylePerWebRequest());
        }
    }
}