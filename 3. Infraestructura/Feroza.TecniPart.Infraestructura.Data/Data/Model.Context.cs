﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TecniPartEntities : DbContext
    {
        public TecniPartEntities()
            : base("name=TecniPartEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AplicacionesData> Aplicaciones { get; set; }
        public virtual DbSet<CatalogoDetallesData> CatalogoDetalles { get; set; }
        public virtual DbSet<CatalogosData> Catalogos { get; set; }
        public virtual DbSet<FabricantesData> Fabricantes { get; set; }
        public virtual DbSet<ReferenciasData> Referencias { get; set; }
        public virtual DbSet<SistemasData> Sistemas { get; set; }
        public virtual DbSet<SubSistemasData> SubSistemas { get; set; }
        public virtual DbSet<VehiculoSistemasData> VehiculoSistemas { get; set; }
        public virtual DbSet<VehiculoSubSistemasData> VehiculoSubSistemas { get; set; }
        public virtual DbSet<EstadoMaestrasData> EstadoMaestras { get; set; }
        public virtual DbSet<PaisData> Pais { get; set; }
        public virtual DbSet<MarcasData> Marcas { get; set; }
        public virtual DbSet<ProductosData> Productos { get; set; }
    }
}
