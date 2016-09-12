// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPaisRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the IPaisRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The PaisRespositorio interface.
    /// </summary>
    public interface IPaisRespositorio
    {
        /// <summary>
        /// Crears the specified descripcion.
        /// </summary>
        /// <param name="descripcion">The descripcion.</param>
        void Crear(string descripcion);

        /// <summary>
        /// Eliminars the specified identifier estado maestras.
        /// </summary>
        /// <param name="idPais">The identifier estado maestras.</param>
        void Eliminar(int idPais);

        /// <summary>The listar estado maestras.</summary>
        /// <param name="idPais">The id estado maestras.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Pais/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Pais> Listar(int idPais);

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Pais/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Pais> Listar();
    }
}
