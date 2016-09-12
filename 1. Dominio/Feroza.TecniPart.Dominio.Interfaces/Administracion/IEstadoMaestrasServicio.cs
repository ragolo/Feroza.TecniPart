// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEstadoMaestrasServicio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The EstadoMaestrasServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The EstadoMaestrasServicio interface.
    /// </summary>
    public interface IEstadoMaestrasServicio
    {
        /// <summary>The add estado maestras.</summary>
        /// <param name="estadoMaestras">The estado maestras.</param>
        /// <returns>The <see cref="EstadoMaestras"/>.</returns>
        EstadoMaestras AddEstadoMaestras(EstadoMaestras estadoMaestras);

        /// <summary>
        /// Deletes the estado maestras.
        /// </summary>
        /// <param name="idEstadoMaestras">The identifier estado maestras.</param>
        void DeleteEstadoMaestras(int idEstadoMaestras);

        /// <summary>
        /// Lists the estado maestras.
        /// </summary>
        /// <param name="idEstadoMaestras">The identifier estado maestras.</param>
        /// <returns>list of the EstadoMaestras</returns>
        IEnumerable<EstadoMaestras> ListEstadoMaestras(int idEstadoMaestras);

        /// <summary>The list estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<EstadoMaestras/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<EstadoMaestras> ListEstadoMaestras();
    }
}