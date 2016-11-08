// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TiposProductos.cs" company="">
//   
// </copyright>
// <summary>
//   The tipos productos.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>The tipos productos.</summary>
    public class TiposProductos
    {
        /// <summary>Initializes a new instance of the <see cref="TiposProductos"/> class.</summary>
        public TiposProductos()
        {
            this.MarcasTiposProductos = new List<MarcasTiposProductos>();
        }

        /// <summary>Gets or sets the id tipos productos.</summary>
        [Key]
        public int IdTiposProductos { get; set; }

        /// <summary>Gets or sets the id lineas productos.</summary>
        public int IdLineasProductos { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        public string Nombre { get; set; }

        /// <summary>Gets or sets the descripcion.</summary>
        public string Descripcion { get; set; }

        /// <summary>Gets or sets the imagen.</summary>
        public byte[] Imagen { get; set; }

        /// <summary>Gets or sets the lineas productos.</summary>
        public virtual LineasProductos LineasProductos { get; set; }

        /// <summary>Gets or sets the marcas tipos productos.</summary>
        public virtual ICollection<MarcasTiposProductos> MarcasTiposProductos { get; set; }

        /// <summary>Gets or sets the sistemas.</summary>
        public virtual ICollection<Sistemas> Sistemas { get; set; }
    }
}