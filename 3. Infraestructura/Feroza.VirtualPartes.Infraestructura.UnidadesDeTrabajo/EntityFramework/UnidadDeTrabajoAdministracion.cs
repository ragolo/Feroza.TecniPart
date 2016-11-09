// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnidadDeTrabajoAdministracion.cs" company="">
//   
// </copyright>
// <summary>
//   The unidad de trabajo administracion.
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
    using Dominio.Interfaces.Administracion;
    using Dominio.RepositorioContratos;

    /// <summary>The unidad de trabajo administracion.</summary>
    public class UnidadDeTrabajoAdministracion : BaseContext<UnidadDeTrabajoAdministracion>, IUnidadDeTrabajoAdministracion
    {

        #region "metodos privados"

        /// <summary>The paises repositorio.</summary>
        private IRepositorio<Paises> paisesRepositorio;

        /// <summary>The marcas repositorio.</summary>
        private IRepositorio<Marcas> marcasRepositorio;

        /// <summary>The fabricantes repositorio.</summary>
        private IRepositorio<Fabricantes> fabricantesRepositorio;

        #endregion

        #region "Constructor"

        public UnidadDeTrabajoAdministracion()
        {
            this.paisesRepositorio = new RepositorioGenerico<Paises>(this.Paises);
            this.marcasRepositorio = new RepositorioGenerico<Marcas>(this.Marcas);
            this.fabricantesRepositorio = new RepositorioGenerico<Fabricantes>(this.Fabricantes);
        }

        #endregion

        #region "implementar unidad de trabajo"

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

        #region "implementar unidad de trabajo administracion"

        /// <summary>Gets or sets the paises.</summary>
        public DbSet<Paises> Paises { get; set; }

        /// <summary>Gets or sets the marcas.</summary>
        public DbSet<Marcas> Marcas { get; set; }

        /// <summary>Gets or sets the fabricantes.</summary>
        public DbSet<Fabricantes> Fabricantes { get; set; }

        /// <summary>The paises repositorio.</summary>
        IRepositorio<Paises> IUnidadDeTrabajoAdministracion.PaisesRepositorio => this.paisesRepositorio;

        /// <summary>The marcas repositorio.</summary>
        IRepositorio<Marcas> IUnidadDeTrabajoAdministracion.MarcasRepositorio => this.marcasRepositorio;

        /// <summary>The fabricantes repositorio.</summary>
        IRepositorio<Fabricantes> IUnidadDeTrabajoAdministracion.FabricantesRepositorio => this.fabricantesRepositorio;


        #endregion

        // Sobre escribimos OnModelCreating de DdContext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Ignore<MarcasTiposProductos>();
            //modelBuilder.Ignore<Referencias>();
            modelBuilder.Ignore<Ciudades>();

            modelBuilder.Entity<Paises>()
                .HasMany(e => e.Departamentos)
                .WithRequired(e => e.Paises)
                .HasForeignKey(e => e.IdPais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paises>()
              .HasMany(e => e.Fabricantes)
              .WithRequired(e => e.Paises)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fabricantes>()
            .HasMany(e => e.Marcas)
            .WithRequired(e => e.Fabricantes)
            .WillCascadeOnDelete(false);
        }
    }
}
