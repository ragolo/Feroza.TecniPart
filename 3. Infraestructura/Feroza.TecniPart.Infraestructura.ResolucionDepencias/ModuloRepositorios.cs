// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuloRepositorios.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The modulo repositorios.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Infraestructura.ResolucionDepencias
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Data.Repositorios.Administracion;

    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The modulo repositorios.
    /// </summary>
    public class ModuloRepositorios : IWindsorInstaller
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
                Component.For<IFabricantesRespositorio>().ImplementedBy<EfFabricantesRepositorio>().LifestyleTransient(),
                Component.For<IMarcasRespositorio>().ImplementedBy<EfMarcasRepositorio>().LifestyleTransient(),
                Component.For<IVehiculosRespositorio>().ImplementedBy<EfVehiculosRepositorio>().LifestyleTransient(),

                Component.For<IPaisRespositorio>().ImplementedBy<EfPaisRepositorio>().LifestyleTransient());
        }
    }
}