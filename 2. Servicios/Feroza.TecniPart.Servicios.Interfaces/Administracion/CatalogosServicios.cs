// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogosServicios.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   The estado maestras servicios.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class CatalogosServicios : ICatalogosServicio
    {
        /// <summary>
        /// The estado maestras repositorio.
        /// </summary>
        private readonly ICatalogosRespositorio catalogosRepositorio;

        /// <summary>Initializes a new instance of the <see cref="CatalogosServicios"/> class.</summary>
        /// <param name="catalogosRepositorio">The Catalogos repositorio.</param>
        public CatalogosServicios(ICatalogosRespositorio catalogosRepositorio)
        {
            this.catalogosRepositorio = catalogosRepositorio;
        }

        /// <summary>The add Catalogos.</summary>
        /// <param name="catalogos">The Catalogos.</param>
        /// <returns>The <see cref="Catalogos"/>.</returns>
        public Catalogos AddCatalogos(Catalogos catalogos)
        {
            return this.catalogosRepositorio.Crear(catalogos);
        }

        /// <summary>The edit Catalogos.</summary>
        /// <param name="catalogos">The Catalogos.</param>
        /// <returns>The <see cref="Catalogos"/>.</returns>
        public Catalogos EditCatalogos(Catalogos catalogos)
        {
            return this.catalogosRepositorio.Editar(catalogos);
        }

        /// <summary>The delete Catalogos.</summary>
        /// <param name="idCatalogos">The id Catalogos.</param>
        public void DeleteCatalogos(int idCatalogos)
        {
            this.catalogosRepositorio.Eliminar(idCatalogos);
        }

        /// <summary>The list Catalogos.</summary>
        /// <param name="idCatalogos">The id Catalogos.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Catalogos> ListCatalogos(int idCatalogos)
        {
            var catalogos = this.catalogosRepositorio.ListarCatalogos(idCatalogos);

            return catalogos;
        }

        /// <summary>The list Catalogos.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Catalogos> ListCatalogos()
        {
            var catalogos = this.catalogosRepositorio.ListarCatalogoses();

            return catalogos;
        }
    }
}