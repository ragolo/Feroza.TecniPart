// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPaisServicio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The PaisServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The PaisServicio interface.
    /// </summary>
    public interface IPaisServicio
    {
        /// <summary>Adds the estado maestras.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="Pais"/>.</returns>
        Pais AddPais(Pais pais);

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="Pais"/>.</returns>
        Pais EditPais(Pais pais);

        /// <summary>
        /// Deletes the estado maestras.
        /// </summary>
        /// <param name="idPais">The identifier estado maestras.</param>
        void DeletePais(int idPais);

        /// <summary>
        /// Lists the estado maestras.
        /// </summary>
        /// <param name="idPais">The identifier estado maestras.</param>
        /// <returns>list of the Pais</returns>
        IEnumerable<Pais> ListPais(int idPais);

        /// <summary>The list estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Pais/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Pais> ListPais();
    }
}