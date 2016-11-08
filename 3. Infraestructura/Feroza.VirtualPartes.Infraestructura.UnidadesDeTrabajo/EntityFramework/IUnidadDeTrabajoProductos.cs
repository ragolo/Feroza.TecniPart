// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnidadDeTrabajoAdministracionInicial.cs" company="">
//   
// </copyright>
// <summary>
//   The UnidadDeTrabajoAdministracionInicial interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.UnidadesDeTrabajo.EntityFramework
{
    using System.Data.Entity;

    using Dominio.Entidades.Modelos.Productos;

    using MarcasTiposProductos = Dominio.Entidades.Modelos.MarcasTiposProductos;

    /// <summary>The UnidadDeTrabajoProductos interface.</summary>
    public interface IUnidadDeTrabajoProductos : IUnidadDeTrabajoEntityFramework
    {
        /// <summary>Gets the lineas productos.</summary>
        IDbSet<LineasProductos> LineasProductos { get; }

        /// <summary>Gets the marcas tipos productos.</summary>
        IDbSet<MarcasTiposProductos> MarcasTiposProductos { get; }

        /// <summary>Gets the productos.</summary>
        IDbSet<Productos> Productos { get; }

        /// <summary>Gets the productos sistemas.</summary>
        IDbSet<ProductosSistemas> ProductosSistemas { get;  }

        /// <summary>Gets the tipos productos.</summary>
        IDbSet<TiposProductos> TiposProductos { get; }
    }
}