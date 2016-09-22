// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductosServicio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The ProductosServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The ProductosServicio interface.
    /// </summary>
    public interface IProductosServicio
    {
        /// <summary>Adds the estado maestras.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="Productos"/>.</returns>
        Productos AddProductos(Productos pais);

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="Productos"/>.</returns>
        Productos EditProductos(Productos pais);

        /// <summary>
        /// Deletes the estado maestras.
        /// </summary>
        /// <param name="idProductos">The identifier estado maestras.</param>
        void DeleteProductos(int idProductos);

        /// <summary>
        /// Lists the estado maestras.
        /// </summary>
        /// <param name="idProductos">The identifier estado maestras.</param>
        /// <returns>list of the Productos</returns>
        IEnumerable<Productos> ListProductos(int idProductos);

        /// <summary>The list estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Productos/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Productos> ListProductos();
    }
}