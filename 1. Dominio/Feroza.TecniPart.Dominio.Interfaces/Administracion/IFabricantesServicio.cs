// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFabricantesServicio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The FabricantesServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The FabricantesServicio interface.
    /// </summary>
    public interface IFabricantesServicio
    {
        /// <summary>Adds the estado maestras.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="Fabricantes"/>.</returns>
        Fabricantes AddFabricantes(Fabricantes pais);

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="Fabricantes"/>.</returns>
        Fabricantes EditFabricantes(Fabricantes pais);

        /// <summary>
        /// Deletes the estado maestras.
        /// </summary>
        /// <param name="idFabricantes">The identifier estado maestras.</param>
        void DeleteFabricantes(int idFabricantes);

        /// <summary>
        /// Lists the estado maestras.
        /// </summary>
        /// <param name="idFabricantes">The identifier estado maestras.</param>
        /// <returns>list of the Fabricantes</returns>
        IEnumerable<Fabricantes> ListFabricantes(int idFabricantes);

        /// <summary>The list estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Fabricantes/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Fabricantes> ListFabricantes();
    }
}