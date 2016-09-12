// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfPaisRepositorio.cs" company="Feroza">
//  Derechos de autor Feroza 
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
    public class EfPaisRepositorio : IPaisRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>Initializes a new instance of the <see cref="EfPaisRepositorio"/> class.</summary>
        public EfPaisRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>
        /// The crear.
        /// </summary>
        /// <param name="descripcion">
        /// The descripcion.
        /// </param>
        public void Crear(string descripcion)
        {
            var pais = this.context.Pais.Create();
            pais.Descripcion = descripcion;
            this.context.SaveChanges();
        }

        /// <summary>
        /// The eliminar.
        /// </summary>
        /// <param name="idPais">
        /// The id estado maestras.
        /// </param>
        public void Eliminar(int idPais)
        {
            var estadoMaestraToDelete = this.context.Pais.FirstOrDefault(r => r.IdPais.Equals(idPais));
            this.context.Pais.Remove(estadoMaestraToDelete);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The listar estado maestras.
        /// </summary>
        /// <param name="idPais">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        public IEnumerable<Pais> Listar(int idPais)
        {
            return this.context.Pais.Where(r => r.IdPais == idPais).Select(s => new Pais
            {
                Descripcion = s.Descripcion,
                IdPais = s.IdPais
            });
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Pais/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Pais> Listar()
        {
            return this.context.Pais.Select(s => new Pais
            {
                Descripcion = s.Descripcion,
                IdPais = s.IdPais
            });
        }
    }
}