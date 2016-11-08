// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnidadDeTrabajoProductos.cs" company="">
//   
// </copyright>
// <summary>
//   The unidad de trabajo productos.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.UnidadesDeTrabajo.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using BaseData;

    using Data.RepositoriosEf;

    using Dominio.Entidades.Modelos;
    using Dominio.Entidades.Modelos.Productos;
    using Dominio.Interfaces.Administracion.Productos;
    using Dominio.RepositorioContratos;

    using Feroza.VirtualPartes.Dominio.Entidades.Modelos.Referencias;

    /// <summary>The unidad de trabajo productos.</summary>
    public class UnidadDeTrabajoProductos : BaseContext<UnidadDeTrabajoProductos>, IUnidadDeTrabajoProductos
    {
        #region "metodos privados"
        /// <summary>The lineas productos repositorio.</summary>
        private readonly IRepositorio<LineasProductos> lineasProductosRepositorio;

        /// <summary>The marcas tipos productos repositorio.</summary>
        private readonly IRepositorio<MarcasTiposProductos> marcasTiposProductosRepositorio;

        /// <summary>The productos repositorio.</summary>
        private readonly IRepositorio<Productos> productosRepositorio;

        /// <summary>The productos sistemas repositorio.</summary>
        private readonly IRepositorio<ProductosSistemas> productosSistemasRepositorio;

        /// <summary>The tipos productos repositorio.</summary>
        private readonly IRepositorio<TiposProductos> tiposProductosRepositorio;

        /// <summary>The sistemas repositorio.</summary>
        private readonly IRepositorio<Sistemas> sistemasRepositorio;
        #endregion 

        #region "Constructor"

        public UnidadDeTrabajoProductos()
        {
            this.lineasProductosRepositorio = new RepositorioGenerico<LineasProductos>(this.LineasProductos);
            this.marcasTiposProductosRepositorio = new RepositorioGenerico<MarcasTiposProductos>(this.MarcasTiposProductos);
            this.productosRepositorio = new RepositorioGenerico<Productos>(this.Productos);
            this.productosSistemasRepositorio = new RepositorioGenerico<ProductosSistemas>(this.ProductosSistemas);
            this.tiposProductosRepositorio = new RepositorioGenerico<TiposProductos>(this.TiposProductos);
            this.sistemasRepositorio = new RepositorioGenerico<Sistemas>(this.Sistemas);
        }
        #endregion

        #region "Implementación unidad de trabajo"
        /// <summary>The confirmar.</summary>
        public void Confirmar()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var updateException = (UpdateException)ex.InnerException;
                if (updateException != null)
                {
                    var sqlException = (SqlException)updateException.InnerException;
                    var sb = new StringBuilder();

                    foreach (SqlError error in sqlException.Errors)
                    {
                        sb.AppendLine(error.Message);
                    }

                    throw new Exception(sb.ToString());
                }

                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>The confirmar y refrescar cambios.</summary>
        public void ConfirmarYRefrescarCambios()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();
                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });
                }
            } while (saveFailed);
        }

        public void Revertir()
        {
            base.ChangeTracker.Entries()
                          .ToList()
                          .ForEach(entry => entry.State = EntityState.Unchanged);
        }
        #endregion

        #region "Implementacion UnidadDeTrabajoProductos"

        /// <summary>Gets or sets the lineas productos.</summary>
        public DbSet<LineasProductos> LineasProductos { get; set; }

        /// <summary>Gets or sets the marcas tipos productos.</summary>
        public DbSet<MarcasTiposProductos> MarcasTiposProductos { get; set; }

        /// <summary>Gets or sets the productos.</summary>
        public DbSet<Productos> Productos { get; set; }

        /// <summary>Gets or sets the productos sistemas.</summary>
        public DbSet<ProductosSistemas> ProductosSistemas { get; set; }

        /// <summary>Gets or sets the tipos productos.</summary>
        public DbSet<TiposProductos> TiposProductos { get; set; }

        public DbSet<Sistemas> Sistemas { get; set; }

        /// <summary>The lineas productos repositorio.</summary>
        IRepositorio<LineasProductos> IUnidadDeTrabajoProductos.LineasProductosRepositorio => this.lineasProductosRepositorio;

        /// <summary>The marcas tipos productos repositorio.</summary>
        IRepositorio<MarcasTiposProductos> IUnidadDeTrabajoProductos.MarcasTiposProductosRepositorio => this.marcasTiposProductosRepositorio;


        /// <summary>The productos repositorio.</summary>
        IRepositorio<Productos> IUnidadDeTrabajoProductos.ProductosRepositorio => this.productosRepositorio;

        /// <summary>The productos sistemas repositorio.</summary>
        IRepositorio<ProductosSistemas> IUnidadDeTrabajoProductos.ProductosSistemasRepositorio => this.productosSistemasRepositorio;

        /// <summary>The tipos productos repositorio.</summary>
        IRepositorio<TiposProductos> IUnidadDeTrabajoProductos.TiposProductosRepositorio => this.tiposProductosRepositorio;

        IRepositorio<Sistemas> IUnidadDeTrabajoProductos.SistemasRepositorio => this.sistemasRepositorio;

        #endregion

        // Sobre escribimos OnModelCreating de DdContext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Ignore<Ciudades>();
            modelBuilder.Ignore<Referencias>();

            modelBuilder.Entity<Sistemas>()
                 .HasMany(e => e.SistemasHijos)
                 .WithOptional(e => e.Sistemas1)
                 .HasForeignKey(e => e.IdSistemasPadre);

            modelBuilder.Entity<TiposProductos>()
             .HasMany(e => e.Sistemas)
             .WithOptional(e => e.TiposProductos)
             .HasForeignKey(e => e.IdTiposProductos);

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

            modelBuilder.Entity<MarcasTiposProductos>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.MarcasTiposProductos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marcas>()
                .HasMany(e => e.MarcasTiposProductos)
                .WithRequired(e => e.Marcas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marcas>()
    .HasMany(e => e.MarcasTiposProductos)
    .WithRequired(e => e.Marcas)
    .HasForeignKey(e => e.IdMarca)
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

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.ProductosSistemas)
                .WithRequired(e => e.Productos)
                .WillCascadeOnDelete(false);

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

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}
