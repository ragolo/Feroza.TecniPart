namespace Feroza.TecniPart.Infraestructura.Data.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Dominio.Interfaces.Repositorio;

    using RepositoriosEf;
    using RepositoriosEf.Extensions;

    /// <summary>The repository.</summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>The context.</summary>
        private readonly IDbContext context;

        /// <summary>The entities.</summary>
        private IDbSet<T> entities;

        /// <summary>Initializes a new instance of the <see cref="Repository{T}"/> class.</summary>
        /// <param name="context">The context.</param>
        public Repository(IDbContext context)
        {
            this.context = context;
        }

        /// <summary>The get by id.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="T"/>.</returns>
        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>The insert.</summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.Entities.Add(entity);
            this.context.SaveChanges();
        }

        /// <summary>The update.</summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.SetAsModified(entity);
            this.context.SaveChanges();
        }

        /// <summary>The delete.</summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.SetAsDeleted(entity);
            this.context.SaveChanges();
        }

        /// <summary>The get filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
            {
                return this.Entities.Where(filter);
            }

            return this.Entities.ToList();
        }

        /// <summary>The get filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public virtual IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            if (filter != null)
            {
                return this.Entities.Where(filter).IncludeMultiple(includes);
            }

            return this.Entities.IncludeMultiple(includes);
        }

        /// <summary>Gets the entities.</summary>
        private IDbSet<T> Entities
        {
            get
            {
                if (this.entities == null)
                {
                    this.entities = this.context.Set<T>();
                }
                return this.entities;
            }
        }

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}