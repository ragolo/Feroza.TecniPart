//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Feroza.TecniPart.Infraestructura.Data.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class FabricantesData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FabricantesData()
        {
            this.Productos = new HashSet<ProductosData>();
        }
    
        public int IdFabricantes { get; set; }
        public int IdPais { get; set; }
        public string Descripcion { get; set; }
        public byte[] ImagenFabricante { get; set; }
        public int IdEstadoMaestras { get; set; }
    
        public virtual EstadoMaestrasData EstadoMaestras { get; set; }
        public virtual PaisData Pais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductosData> Productos { get; set; }
    }
}
