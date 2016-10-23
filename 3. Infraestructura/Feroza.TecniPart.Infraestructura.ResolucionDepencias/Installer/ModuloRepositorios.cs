// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuloRepositorios.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The modulo repositorios.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Infraestructura.ResolucionDepencias.Installer
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Data.Repositorios;
    using Data.RepositoriosEf;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Repositorio;

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
            //TODO:[Windsor] Hay una manera para no tener que implementar manualmente los repositorios
            container.Register(
                Component.For<IDbContext>().ImplementedBy<IocDbContext>().LifestylePerWebRequest(),
                Component.For<IRepository<Pais>>().ImplementedBy<Repository<Pais>>().LifestylePerWebRequest(),
                Component.For<IRepository<Fabricantes>>().ImplementedBy<Repository<Fabricantes>>().LifestylePerWebRequest(),
                Component.For<IRepository<Marcas>>().ImplementedBy<Repository<Marcas>>().LifestylePerWebRequest(),
                Component.For<IRepository<Vehiculos>>().ImplementedBy<Repository<Vehiculos>>().LifestylePerWebRequest(),
                Component.For<IRepository<Catalogos>>().ImplementedBy<Repository<Catalogos>>().LifestylePerWebRequest(),
                Component.For<IRepository<Referencias>>().ImplementedBy<Repository<Referencias>>().LifestylePerWebRequest(),
                Component.For<IRepository<SubSistemas>>().ImplementedBy<Repository<SubSistemas>>().LifestylePerWebRequest(),
                Component.For<IRepository<Sistemas>>().ImplementedBy<Repository<Sistemas>>().LifestylePerWebRequest());
        }
    }
}