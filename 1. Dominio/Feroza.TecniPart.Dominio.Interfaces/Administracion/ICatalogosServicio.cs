// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICatalogosServicio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The CatalogosServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The CatalogosServicio interface.
    /// </summary>
    public interface ICatalogosServicio
    {
        /// <summary>Adds the estado maestras.</summary>
        /// <param name="catalogos">The catalogos.</param>
        /// <returns>The <see cref="Catalogos"/>.</returns>
        Catalogos AddCatalogos(Catalogos catalogos);

        /// <summary>The edit catalogos.</summary>
        /// <param name="catalogos">The catalogos.</param>
        /// <returns>The <see cref="Catalogos"/>.</returns>
        Catalogos EditCatalogos(Catalogos catalogos);

        /// <summary>
        /// Deletes the estado maestras.
        /// </summary>
        /// <param name="idCatalogos">The identifier estado maestras.</param>
        void DeleteCatalogos(int idCatalogos);

        /// <summary>
        /// Lists the estado maestras.
        /// </summary>
        /// <param name="idCatalogos">The identifier estado maestras.</param>
        /// <returns>list of the Catalogos</returns>
        IEnumerable<Catalogos> ListCatalogos(int idCatalogos);

        /// <summary>The list estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Catalogos/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Catalogos> ListCatalogos();
    }
}