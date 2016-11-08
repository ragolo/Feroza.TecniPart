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
    using Dominio.Entidades.Modelos.Referencias;
    using Dominio.Interfaces.Administracion.Referencias;
    using Dominio.RepositorioContratos;

    /// <summary>The unidad de trabajo productos.</summary>
    public class UnidadDeTrabajoReferencias : BaseContext<UnidadDeTrabajoReferencias>, IUnidadDeTrabajoReferencias
    {
        #region "metodos privados"

        /// <summary>The consecutivos paises oem repositorio.</summary>
        private readonly IRepositorio<ConsecutivosPaisesOEM> consecutivosPaisesOemRepositorio;

        /// <summary>The referencias repositorio.</summary>
        private readonly IRepositorio<Referencias> referenciasRepositorio;


        #endregion 

        #region "Constructor"

        /// <summary>Initializes a new instance of the <see cref="UnidadDeTrabajoReferencias"/> class.</summary>
        public UnidadDeTrabajoReferencias()
        {
            this.consecutivosPaisesOemRepositorio = new RepositorioGenerico<ConsecutivosPaisesOEM>(this.ConsecutivosPaisesOEM);
            this.referenciasRepositorio = new RepositorioGenerico<Referencias>(this.Referencias);
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

        #region "Implementacion UnidadDeTrabajoReferencias"

        /// <summary>Gets or sets the consecutivos paises oem.</summary>
        public virtual DbSet<ConsecutivosPaisesOEM> ConsecutivosPaisesOEM { get; set; }

        /// <summary>Gets or sets the marcas.</summary>
        public virtual DbSet<Marcas> Marcas { get; set; }

        /// <summary>Gets or sets the marcas tipos productos.</summary>
        public virtual DbSet<MarcasTiposProductos> MarcasTiposProductos { get; set; }

        /// <summary>Gets or sets the referencias.</summary>
        public virtual DbSet<Referencias> Referencias { get; set; }

        /// <summary>The consecutivos paises oem repositorio.</summary>
        IRepositorio<ConsecutivosPaisesOEM> IUnidadDeTrabajoReferencias.ConsecutivosPaisesOemRepositorio => this.consecutivosPaisesOemRepositorio;

        /// <summary>The referencias repositorio.</summary>
        IRepositorio<Referencias> IUnidadDeTrabajoReferencias.ReferenciasRepositorio => this.referenciasRepositorio;

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Ignore<Ciudades>();
            modelBuilder.Ignore<Productos>();

            modelBuilder.Entity<ConsecutivosPaisesOEM>()
               .Property(e => e.CodigoOEM)
               .IsUnicode(false);

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
                .HasMany(e => e.Referencias)
                .WithRequired(e => e.MarcasTiposProductos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Referencias>()
                .Property(e => e.CodigoOEM)
                .IsUnicode(false);

            modelBuilder.Entity<Referencias>()
                .Property(e => e.CodigoFabricacion)
                .IsUnicode(false);

            modelBuilder.Entity<Referencias>()
                .Property(e => e.ReferenciaVP)
                .IsUnicode(false);

            modelBuilder.Entity<Referencias>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Referencias>()
                .Property(e => e.DescripcionTecnica)
                .IsUnicode(false);
        }

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}
