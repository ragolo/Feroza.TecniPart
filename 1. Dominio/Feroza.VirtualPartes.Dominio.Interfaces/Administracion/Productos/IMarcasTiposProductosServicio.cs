// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMarcasTiposProductosServicio.cs" company="">
//   
// </copyright>
// <summary>
//   The MarcasTiposProductosServicio  interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Interfaces.Administracion.Productos
{
    using System.Collections.Generic;

    using Entidades.Modelos.Productos;

    /// <summary>The MarcasTiposProductosServicio  interface.</summary>
    public interface IMarcasTiposProductosServicio : IServicio<MarcasTiposProductos>
    {
        /// <summary>The obtener lista tipos productos por marcas tipos.</summary>
        /// <returns>The <see cref="IList"/>.</returns>
        IList<LineasProductos> ObtenerListaTiposProductosPorMarcasTipos();
    }
}