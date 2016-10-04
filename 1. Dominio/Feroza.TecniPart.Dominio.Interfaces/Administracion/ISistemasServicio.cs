// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISistemasServicio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The SistemasServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The SistemasServicio interface.
    /// </summary>
    public interface ISistemasServicio
    {
        /// <summary>The add sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="Sistemas"/>.</returns>
        Sistemas AddSistemas(Sistemas sistemas);

        /// <summary>The edit sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="Sistemas"/>.</returns>
        Sistemas EditSistemas(Sistemas sistemas);

        /// <summary>The delete sistemas.</summary>
        /// <param name="idSistemas">The id sistemas.</param>
        void DeleteSistemas(int idSistemas);

        /// <summary>The list sistemas.</summary>
        /// <param name="idSistemas">The id sistemas.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<Sistemas> ListSistemas(int idSistemas);

        /// <summary>The list sistemas.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<Sistemas> ListSistemas();
    }
}