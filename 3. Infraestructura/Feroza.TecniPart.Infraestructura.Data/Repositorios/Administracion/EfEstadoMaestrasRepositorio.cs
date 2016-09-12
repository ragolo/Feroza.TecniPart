// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfEstadoMaestrasRepositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The ef estado maestras repositorio.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Infraestructura.Data.Repositorios.Administracion
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The ef estado maestras repositorio.
    /// </summary>
    public class EfEstadoMaestrasRepositorio : IEstadoMaestrasRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfEstadoMaestrasRepositorio"/> class.
        /// </summary>
        public EfEstadoMaestrasRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>The crear.</summary>
        /// <param name="descripcion">The descripcion.</param>
        /// <returns>The <see cref="EstadoMaestras"/>.</returns>
        public EstadoMaestras Crear(string descripcion)
        {
            var estadoMaestrasData = this.context.EstadoMaestras.Create();
            estadoMaestrasData.Desripcion = descripcion;
            this.context.SaveChanges();
            var estadoMaestras = new EstadoMaestras
                                     {
                                         Desripcion = estadoMaestrasData.Desripcion,
                                         IdEstadoMaestras = estadoMaestrasData.IdEstadoMaestras
                                     };
            return estadoMaestras;
        }

        /// <summary>
        /// The eliminar.
        /// </summary>
        /// <param name="idEstadoMaestras">
        /// The id estado maestras.
        /// </param>
        public void Eliminar(int idEstadoMaestras)
        {
            var estadoMaestraToDelete = this.context.EstadoMaestras.FirstOrDefault(r => r.IdEstadoMaestras.Equals(idEstadoMaestras));
            this.context.EstadoMaestras.Remove(estadoMaestraToDelete);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The listar estado maestras.
        /// </summary>
        /// <param name="idEstadoMaestras">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<EstadoMaestras> ListarEstadoMaestras(int idEstadoMaestras)
        {
            return this.context.EstadoMaestras.Where(r => r.IdEstadoMaestras == idEstadoMaestras).Select(s => new EstadoMaestras
            {
                Desripcion = s.Desripcion,
                IdEstadoMaestras = s.IdEstadoMaestras
            });
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<EstadoMaestras/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<EstadoMaestras> ListarEstadoMaestras()
        {
            return this.context.EstadoMaestras.Select(s => new EstadoMaestras
            {
                Desripcion = s.Desripcion,
                IdEstadoMaestras = s.IdEstadoMaestras
            });
        }
    }
}