// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasTiposProductos.cs" company="">
//   
// </copyright>
// <summary>
//   The marcas tipos productos.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Referencias;

    /// <summary>The marcas tipos productos.</summary>
    public class MarcasTiposProductos
    {
        /// <summary>Initializes a new instance of the <see cref="MarcasTiposProductos"/> class.</summary>
        public MarcasTiposProductos()
        {
            this.Productos = new List<Productos>();
            this.Referencias = new List<Referencias>();
        }

        /// <summary>Gets or sets the id marcas tipos productos.</summary>
        [Key]
        public int IdMarcasTiposProductos { get; set; }

        /// <summary>Gets or sets the id marca.</summary>
        public int IdMarca { get; set; }

        /// <summary>Gets or sets the id tipos productos.</summary>
        public int IdTiposProductos { get; set; }

        /// <summary>Gets or sets the tipos productos.</summary>
        public virtual TiposProductos TiposProductos { get; set; }

        /// <summary>Gets or sets the marcas.</summary>
        public virtual Marcas Marcas { get; set; }

        /// <summary>Gets or sets the productos.</summary>
        public virtual ICollection<Productos> Productos { get; set; }

        /// <summary>Gets or sets the referencias.</summary>
        public virtual ICollection<Referencias> Referencias { get; set; }
    }
}