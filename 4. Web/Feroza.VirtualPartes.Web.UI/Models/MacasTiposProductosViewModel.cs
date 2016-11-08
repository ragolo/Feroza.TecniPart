// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasTiposProductosViewModel.cs" company="Feroza">
//   

// </copyright>
// <summary>
//   Defines the MarcasTiposProductosViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Models
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;

    using Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos;

    /// <summary>The fabricantes view model.</summary>
    public class MarcasTiposProductosViewModel : MarcasTiposProductos
    {
        /// <summary>Initializes a new instance of the <see cref="MarcasTiposProductosViewModel"/> class.</summary>
        public MarcasTiposProductosViewModel()
        {
            this.TiposProductosList = new List<TiposProductos>();
            this.MarcasList = new List<Marcas>();
        }

        public IEnumerable<TiposProductos> TiposProductosList { get; set; }

        public IEnumerable<Marcas> MarcasList { get; set; }
    }
}