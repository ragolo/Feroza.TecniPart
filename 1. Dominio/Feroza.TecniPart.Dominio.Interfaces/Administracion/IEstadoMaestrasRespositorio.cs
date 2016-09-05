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
        /// <summary>
        /// Crears the specified descripcion.
        /// </summary>
        /// <param name="descripcion">The descripcion.</param>
        void Crear(string descripcion);

        /// <summary>
        /// Eliminars the specified identifier estado maestras.
        /// </summary>
        /// <param name="idEstadoMaestras">The identifier estado maestras.</param>
        void Eliminar(int idEstadoMaestras);

        /// <summary>
        /// Listars the estado maestras.
        /// </summary>
        /// <param name="idEstadoMaestras">The identifier estado maestras.</param>
        /// <returns></returns>
        IEnumerable<EstadoMaestras> ListarEstadoMaestras(int idEstadoMaestras);
    }
}
