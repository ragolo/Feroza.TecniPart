// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISistemasRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the ISistemasRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The SistemasRespositorio interface.
    /// </summary>
    public interface ISistemasRespositorio
    {
        /// <summary>Crears the specified descripcion.</summary>
        /// <param name="sistemas"></param>
        /// <returns>The <see cref="Sistemas"/>.</returns>
        Sistemas Crear(Sistemas sistemas);

        /// <summary>The editar.</summary>
        /// <param name="sistemas"></param>
        /// <returns>The <see cref="Sistemas"/>.</returns>
        Sistemas Editar(Sistemas sistemas);

        /// <summary>
        /// Eliminars the specified identifier estado maestras.
        /// </summary>
        /// <param name="idSistemas">The identifier estado maestras.</param>
        void Eliminar(int idSistemas);

        /// <summary>The listar sistemas.</summary>
        /// <param name="idSistemas">The id sistemas.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<Sistemas> ListarSistemas(int idSistemas);

        /// <summary>The listar sistemases.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<Sistemas> ListarSistemases();
    }
}
