// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductosRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the IProductosRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The ProductosRespositorio interface.
    /// </summary>
    public interface IProductosRespositorio
    {
        /// <summary>Crears the specified descripcion.</summary>
        /// <param name="pais"></param>
        /// <returns>The <see cref="Productos"/>.</returns>
        Productos Crear(Productos pais);

        /// <summary>The editar.</summary>
        /// <param name="pais"></param>
        /// <returns>The <see cref="Productos"/>.</returns>
        Productos Editar(Productos pais);

        /// <summary>
        /// Eliminars the specified identifier estado maestras.
        /// </summary>
        /// <param name="idProductos">The identifier estado maestras.</param>
        void Eliminar(int idProductos);

        /// <summary>The listar estado maestras.</summary>
        /// <param name="idProductos">The id estado maestras.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Productos/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Productos> ListarProductos(int idProductos);

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Productos/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Productos> ListarProductoses();
    }
}
