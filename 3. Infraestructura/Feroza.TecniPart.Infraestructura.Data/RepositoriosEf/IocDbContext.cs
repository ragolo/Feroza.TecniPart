namespace Feroza.TecniPart.Infraestructura.Data.RepositoriosEf
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;

    using Data;

    /// <summary>The ioc db context.</summary>
    public class IocDbContext : TecniPartEntities, IDbContext
    {
        //TODO: Centralizar el lanzamiento de exceptions para esta clase, para cuando salgmos a producción no exponer informacion de la base de datos
        /// <summary>Initializes a new instance of the <see cref="IocDbContext"/> class.</summary>
        public IocDbContext()
            : base("name=TecniPartEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>The set as added.</summary>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TEntity"></typeparam>
        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                this.GetDbEntityEntrySafely(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>The set as modified.</summary>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TEntity"></typeparam>
        public void SetAsModified<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                this.GetDbEntityEntrySafely(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>The set as deleted.</summary>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TEntity"></typeparam>
        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = base.Entry<TEntity>(entity);
                if (dbEntityEntry.State != EntityState.Detached)
                {

                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {

                    DbSet dbSet = base.Set<TEntity>();
                    dbSet.Attach(entity);
                    dbSet.Remove(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>The save changes.</summary>
        /// <returns>The <see cref="int"/>.</returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format(
                                   "Property: {0} Error: {1}",
                                   validationError.PropertyName,
                                   validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>The dispose.</summary>
        public new void Dispose()
        {
            try
            {
                base.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>The set.</summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="IDbSet"/>.</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        /// <summary>The get db entity entry safely.</summary>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="DbEntityEntry"/>.</returns>
        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                var dbEntityEntry = base.Entry<TEntity>(entity);
                if (dbEntityEntry.State == EntityState.Detached)
                {
                    base.Set<TEntity>().AddOrUpdate(entity);
                }

                return dbEntityEntry;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}