namespace Feroza.VirtualPartes.Infraestructura.Data.TEM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MarcasTiposProductos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MarcasTiposProductos()
        {
            Productos = new HashSet<Productos>();
        }

        [Key]
        public int IdMarcasTiposProductos { get; set; }

        public int IdMarca { get; set; }

        public int IdTiposProductos { get; set; }

        public virtual Marcas Marcas { get; set; }

        public virtual TiposProductos TiposProductos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
