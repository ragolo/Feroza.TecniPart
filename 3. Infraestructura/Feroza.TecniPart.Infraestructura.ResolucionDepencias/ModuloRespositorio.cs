// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuloRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the ModuloRespositorio type.
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
    /// The modulo respositorio.
    /// </summary>
    public class ModuloRespositorio : IWindsorInstaller
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
                Component.For<IEstadoMaestrasRespositorio>()
                    .ImplementedBy<EfEstadoMaestrasRepositorio>()
                    .LifestyleTransient());
        }
    }
}