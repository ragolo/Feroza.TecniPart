// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TiposProductosViewModel.cs" company="Feroza">
//   

// </copyright>
// <summary>
//   Defines the TiposProductosViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Models
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;

    using Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos;

    /// <summary>The fabricantes view model.</summary>
    public class TiposProductosViewModel : TiposProductos
    {
        /// <summary>Initializes a new instance of the <see cref="TiposProductosViewModel"/> class.</summary>
        public TiposProductosViewModel()
        {
            this.LineasProductosList = new List<LineasProductos>();
        }

        public IEnumerable<LineasProductos> LineasProductosList { get; set; }
    }
}