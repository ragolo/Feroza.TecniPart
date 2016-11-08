namespace Feroza.VirtualPartes.Infraestructura.Data.TEM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TiposProductos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TiposProductos()
        {
            MarcasTiposProductos = new HashSet<MarcasTiposProductos>();
        }

        [Key]
        public int IdTiposProductos { get; set; }

        public int IdLineasProductos { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        [Column(TypeName = "image")]
        public byte[] Imagen { get; set; }

        public virtual LineasProductos LineasProductos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarcasTiposProductos> MarcasTiposProductos { get; set; }
    }
}
