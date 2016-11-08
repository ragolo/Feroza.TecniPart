// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductosViewModel.cs" company="Feroza">
//   

// </copyright>
// <summary>
//   Defines the ProductosViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Models
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;

    using Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos;

    /// <summary>The fabricantes view model.</summary>
    public class ProductosViewModel : Productos
    {
        /// <summary>Initializes a new instance of the <see cref="ProductosViewModel"/> class.</summary>
        public ProductosViewModel()
        {
            this.MarcasTiposProductosList = new List<MarcasTiposProductos>();
        }

        public IEnumerable<MarcasTiposProductos> MarcasTiposProductosList { get; set; }
    }
}