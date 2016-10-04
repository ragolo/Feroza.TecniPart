// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISubSistemasServicio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The SubSistemasServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The SubSistemasServicio interface.
    /// </summary>
    public interface ISubSistemasServicio
    {
        /// <summary>The add sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="SubSistemas"/>.</returns>
        SubSistemas AddSubSistemas(SubSistemas sistemas);

        /// <summary>The edit sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="SubSistemas"/>.</returns>
        SubSistemas EditSubSistemas(SubSistemas sistemas);

        /// <summary>The delete sistemas.</summary>
        /// <param name="idSubSistemas">The id sistemas.</param>
        void DeleteSubSistemas(int idSubSistemas);

        /// <summary>The list sistemas.</summary>
        /// <param name="idSubSistemas">The id sistemas.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<SubSistemas> ListSubSistemas(int idSubSistemas);

        /// <summary>The list sistemas.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<SubSistemas> ListSubSistemas();
    }
}