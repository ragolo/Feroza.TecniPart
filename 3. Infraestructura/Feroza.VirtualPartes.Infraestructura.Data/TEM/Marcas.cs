namespace Feroza.VirtualPartes.Infraestructura.Data.TEM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Marcas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marcas()
        {
            MarcasTiposProductos = new HashSet<MarcasTiposProductos>();
        }

        [Key]
        public int IdMarcas { get; set; }

        public int IdFabricantes { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        [StringLength(10)]
        public string Sigla { get; set; }

        public byte[] Imagen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarcasTiposProductos> MarcasTiposProductos { get; set; }
    }
}
