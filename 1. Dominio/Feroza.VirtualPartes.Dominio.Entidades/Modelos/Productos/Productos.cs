// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Productos.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Productos type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>The productos.</summary>
    public class Productos
    {
        /// <summary>Initializes a new instance of the <see cref="Productos"/> class.</summary>
        public Productos()
        {
            this.ProductosSistemas = new List<ProductosSistemas>();
        }

        /// <summary>Gets or sets the id productos.</summary>
        [Key]
        public int IdProductos { get; set; }

        /// <summary>Gets or sets the id marcas tipos productos.</summary>
        public int IdMarcasTiposProductos { get; set; }

        /// <summary>Gets or sets the version.</summary>
        public string Version { get; set; }

        /// <summary>Gets or sets the anio.</summary>
        public int Anio { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        public string Nombre { get; set; }

        /// <summary>Gets or sets the descripcion.</summary>
        public string Descripcion { get; set; }

        /// <summary>Gets or sets the imagen.</summary>
        public byte[] Imagen { get; set; }

        /// <summary>Gets or sets the marcas tipos productos.</summary>
        public virtual MarcasTiposProductos MarcasTiposProductos { get; set; }

        /// <summary>Gets or sets the productos sistemas.</summary>
        public virtual ICollection<ProductosSistemas> ProductosSistemas { get; set; }
    }
}