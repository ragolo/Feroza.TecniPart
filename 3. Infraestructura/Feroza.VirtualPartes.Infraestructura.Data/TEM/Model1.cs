namespace Feroza.VirtualPartes.Infraestructura.Data.TEM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<LineasProductos> LineasProductos { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<MarcasTiposProductos> MarcasTiposProductos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TiposProductos> TiposProductos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineasProductos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<LineasProductos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<LineasProductos>()
                .HasMany(e => e.TiposProductos)
                .WithRequired(e => e.LineasProductos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marcas>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Marcas>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Marcas>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Marcas>()
                .HasMany(e => e.MarcasTiposProductos)
                .WithRequired(e => e.Marcas)
                .HasForeignKey(e => e.IdMarca)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MarcasTiposProductos>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.MarcasTiposProductos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Version)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TiposProductos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TiposProductos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TiposProductos>()
                .HasMany(e => e.MarcasTiposProductos)
                .WithRequired(e => e.TiposProductos)
                .WillCascadeOnDelete(false);
        }
    }
}
