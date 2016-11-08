// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductosSistemas.cs" company="">
//   
// </copyright>
// <summary>
//   The productos sistemas.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>The productos sistemas.</summary>
    public class ProductosSistemas
    {
        /// <summary>Gets or sets the id productos sistemas.</summary>
        [Key]
        public int IdProductosSistemas { get; set; }

        /// <summary>Gets or sets the id sistemas.</summary>
        public int IdSistemas { get; set; }

        /// <summary>Gets or sets the id productos.</summary>
        public int IdProductos { get; set; }

        /// <summary>Gets or sets the productos.</summary>
        public virtual Productos Productos { get; set; }
    }
}