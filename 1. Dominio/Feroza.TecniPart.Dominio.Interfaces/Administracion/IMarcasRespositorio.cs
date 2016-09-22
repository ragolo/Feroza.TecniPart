// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMarcasRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the IMarcasRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The MarcasRespositorio interface.
    /// </summary>
    public interface IMarcasRespositorio
    {
        /// <summary>Crears the specified descripcion.</summary>
        /// <param name="marcas"></param>
        /// <returns>The <see cref="Marcas"/>.</returns>
        Marcas Crear(Marcas marcas);

        /// <summary>The editar.</summary>
        /// <param name="marcas"></param>
        /// <returns>The <see cref="Marcas"/>.</returns>
        Marcas Editar(Marcas marcas);

        /// <summary>
        /// Eliminars the specified identifier estado maestras.
        /// </summary>
        /// <param name="idMarcas">The identifier estado maestras.</param>
        void Eliminar(int idMarcas);

        /// <summary>The listar estado maestras.</summary>
        /// <param name="idMarcas">The id estado maestras.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Marcas/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Marcas> ListarMarcas(int idMarcas);

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Marcas/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Marcas> ListarMarcases();
    }
}
