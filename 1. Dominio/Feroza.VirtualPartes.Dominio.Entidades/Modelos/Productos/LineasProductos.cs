namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>The lineas productos.</summary>
    public class LineasProductos
    {
        /// <summary>Initializes a new instance of the <see cref="LineasProductos"/> class.</summary>
        public LineasProductos()
        {
            this.TiposProductos = new List<TiposProductos>();
        }

        /// <summary>Gets or sets the id lineas productos.</summary>
        [Key]
        public int IdLineasProductos { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        public string Nombre { get; set; }

        /// <summary>Gets or sets the descripcion.</summary>
        public string Descripcion { get; set; }

        /// <summary>Gets or sets the tipos productos.</summary>
        public virtual ICollection<TiposProductos> TiposProductos { get; set; }
    }
}