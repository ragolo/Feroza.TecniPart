// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnidadDeTrabajoProductos.cs" company="">
//   
// </copyright>
// <summary>
//   The UnidadDeTrabajoProductos interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Interfaces.Administracion.Productos
{
    using Entidades.Modelos.Productos;

    using RepositorioContratos;

    /// <summary>The UnidadDeTrabajoProductos interface.</summary>
    public interface IUnidadDeTrabajoProductos : IUnidadDeTrabajo
    {
        /// <summary>Gets the lineas productos repositorio.</summary>
        IRepositorio<LineasProductos> LineasProductosRepositorio { get; }

        /// <summary>Gets the marcas tipos productos repositorio.</summary>
        IRepositorio<MarcasTiposProductos> MarcasTiposProductosRepositorio { get; }

        /// <summary>The productos repositorio.</summary>
        IRepositorio<Productos> ProductosRepositorio { get; }

        IRepositorio<ProductosSistemas> ProductosSistemasRepositorio { get; }

        IRepositorio<TiposProductos> TiposProductosRepositorio { get; }

        IRepositorio<Sistemas> SistemasRepositorio { get; }
    }
}