namespace Feroza.VirtualPartes.Infraestructura.Data.TEM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        [Key]
        public int IdProductos { get; set; }

        public int IdMarcasTiposProductos { get; set; }

        [StringLength(50)]
        public string Version { get; set; }

        public int Anio { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public byte[] Imagen { get; set; }

        public virtual MarcasTiposProductos MarcasTiposProductos { get; set; }
    }
}
