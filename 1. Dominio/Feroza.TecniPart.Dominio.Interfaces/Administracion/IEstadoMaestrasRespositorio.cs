// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEstadoMaestrasRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the IEstadoMaestrasRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The EstadoMaestrasRespositorio interface.
    /// </summary>
    public interface IEstadoMaestrasRespositorio
    {
        /// <summary>The crear.</summary>
        /// <param name="descripcion">The descripcion.</param>
        /// <returns>The <see cref="EstadoMaestras"/>.</returns>
        EstadoMaestras Crear(EstadoMaestras descripcion);

        /// <summary>The editar.</summary>
        /// <param name="estadoMaestras">The estado maestras.</param>
        /// <returns>The <see cref="EstadoMaestras"/>.</returns>
        EstadoMaestras Editar(EstadoMaestras estadoMaestras);

        /// <summary>
        /// Eliminars the specified identifier estado maestras.
        /// </summary>
        /// <param name="idEstadoMaestras">The identifier estado maestras.</param>
        void Eliminar(int idEstadoMaestras);

        /// <summary>The listar estado maestras.</summary>
        /// <param name="idEstadoMaestras">The id estado maestras.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable<EstadoMaestras/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<EstadoMaestras> ListarEstadoMaestras(int idEstadoMaestras);

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<EstadoMaestras/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<EstadoMaestras> ListarEstadoMaestras();
    }
}
