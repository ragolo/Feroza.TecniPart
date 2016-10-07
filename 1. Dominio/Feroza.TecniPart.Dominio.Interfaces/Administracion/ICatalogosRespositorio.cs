// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICatalogosRespositorio.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the ICatalogosRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The CatalogosRespositorio interface.
    /// </summary>
    public interface ICatalogosRespositorio
    {
        /// <summary>Crears the specified descripcion.</summary>
        /// <param name="catalogos"></param>
        /// <returns>The <see cref="Catalogos"/>.</returns>
        Catalogos Crear(Catalogos catalogos);

        /// <summary>The editar.</summary>
        /// <param name="catalogos"></param>
        /// <returns>The <see cref="Catalogos"/>.</returns>
        Catalogos Editar(Catalogos catalogos);

        /// <summary>
        /// Eliminars the specified identifier estado maestras.
        /// </summary>
        /// <param name="idCatalogos">The identifier estado maestras.</param>
        void Eliminar(int idCatalogos);

        /// <summary>The listar estado maestras.</summary>
        /// <param name="idCatalogos">The id estado maestras.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Catalogos/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Catalogos> ListarCatalogos(int idCatalogos);

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Catalogos/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Catalogos> ListarCatalogoses();
    }
}
