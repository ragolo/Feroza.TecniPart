// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISubSistemasRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the ISubSistemasRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The SubSistemasRespositorio interface.
    /// </summary>
    public interface ISubSistemasRespositorio
    {
        /// <summary>The crear.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="SubSistemas"/>.</returns>
        SubSistemas Crear(SubSistemas sistemas);

        /// <summary>The editar.</summary>
        /// <param name="sistemas"></param>
        /// <returns>The <see cref="SubSistemas"/>.</returns>
        SubSistemas Editar(SubSistemas sistemas);

        /// <summary>The eliminar.</summary>
        /// <param name="idSubSistemas">The id sub sistemas.</param>
        void Eliminar(int idSubSistemas);

        /// <summary>The listar sub sistemas.</summary>
        /// <param name="idSubSistemas">The id sub sistemas.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<SubSistemas> ListarSubSistemas(int idSubSistemas);

        /// <summary>The listar sub sistemases.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<SubSistemas> ListarSubSistemases();
    }
}
