// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuloRepositorios.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The modulo repositorios.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.ResolucionDepencias.Installer
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Dominio.Interfaces.Administracion;
    using Dominio.Interfaces.Administracion.Productos;

    using Dominio.Interfaces.Administracion.Referencias;

    using UnidadesDeTrabajo.EntityFramework;

    /// <summary>
    /// The modulo repositorios.
    /// </summary>
    public class ModuloRepositorios : IWindsorInstaller
    {
        /// <summary>The install.</summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnidadDeTrabajoAdministracion>().ImplementedBy<UnidadDeTrabajoAdministracion>().LifestylePerWebRequest(),
                Component.For<IUnidadDeTrabajoReferencias>().ImplementedBy<UnidadDeTrabajoReferencias>().LifestylePerWebRequest(), 
                Component.For<IUnidadDeTrabajoProductos>().ImplementedBy<UnidadDeTrabajoProductos>().LifestylePerWebRequest());
        }
    }
}