// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMarcasServicio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The MarcasServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The MarcasServicio interface.
    /// </summary>
    public interface IMarcasServicio
    {
        /// <summary>Adds the estado maestras.</summary>
        /// <param name="marcas">The marcas.</param>
        /// <returns>The <see cref="Marcas"/>.</returns>
        Marcas AddMarcas(Marcas marcas);

        /// <summary>The edit marcas.</summary>
        /// <param name="marcas">The marcas.</param>
        /// <returns>The <see cref="Marcas"/>.</returns>
        Marcas EditMarcas(Marcas marcas);

        /// <summary>
        /// Deletes the estado maestras.
        /// </summary>
        /// <param name="idMarcas">The identifier estado maestras.</param>
        void DeleteMarcas(int idMarcas);

        /// <summary>
        /// Lists the estado maestras.
        /// </summary>
        /// <param name="idMarcas">The identifier estado maestras.</param>
        /// <returns>list of the Marcas</returns>
        IEnumerable<Marcas> ListMarcas(int idMarcas);

        /// <summary>The list estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Marcas/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Marcas> ListMarcas();
    }
}