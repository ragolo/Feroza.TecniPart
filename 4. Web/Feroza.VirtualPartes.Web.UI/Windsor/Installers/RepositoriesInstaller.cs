// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoriesInstaller.cs" company="">
//   
// </copyright>
// <summary>
//   The repositories installer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Windsor.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Dominio.Interfaces.Administracion;
    using Dominio.Interfaces.Administracion.Productos;

    using Dominio.Interfaces.Administracion.Referencias;

    using Servicios.Interfaces.Administracion;
    using Servicios.Interfaces.Administracion.Producto;

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
                Component.For<IFabricantesServicio>().ImplementedBy<FabricantesServicios>().LifestylePerWebRequest(),
                Component.For<IMarcasServicio>().ImplementedBy<MarcasServicios>().LifestylePerWebRequest(),
                Component.For<ILineasProductosServicio>().ImplementedBy<LineasProductosServicios>().LifestylePerWebRequest(),
                Component.For<IMarcasTiposProductosServicio>().ImplementedBy<MarcasTiposProductosServicios>().LifestylePerWebRequest(),
                Component.For<IProductosServicio>().ImplementedBy<ProductosServicios>().LifestylePerWebRequest(),
                Component.For<ISistemasServicio>().ImplementedBy<SistemasServicios>().LifestylePerWebRequest(),
                Component.For<IReferenciasServicio>().ImplementedBy<ReferenciasServicios>().LifestylePerWebRequest(),
                Component.For<ITiposProductosServicio>().ImplementedBy<TiposProductosServicios>().LifestylePerWebRequest(),
                Component.For<IPaisesServicio>().ImplementedBy<PaisesServicios>().LifestylePerWebRequest());
                //Component.For<IManagementImageFacade<Catalogos>>().ImplementedBy<ManagementImageFacade<Catalogos>>().LifestylePerWebRequest());
        }
    }
}