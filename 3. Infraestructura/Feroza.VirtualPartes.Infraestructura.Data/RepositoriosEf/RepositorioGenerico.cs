// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositorioGenerico.cs" company="">
//   
// </copyright>
// <summary>
//   The repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.Data.RepositoriosEf
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Dominio.RepositorioContratos;

    using Extensions;

    /// <summary>The repositorio generico.</summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositorioGenerico<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;

        public RepositorioGenerico(DbSet<TEntity> dbSet)
        {
            this.dbSet = dbSet;
        }

        public IEnumerable<TEntity> Obtener(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] incluidos)
        {
            IQueryable<TEntity> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var includeMultiple = query.IncludeMultiple(incluidos);
            query = includeMultiple;

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<TEntity> ObtenerTodo()
        {
            return this.dbSet;
        }

        public TEntity ObtenerPorId(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Insertar(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Eliminar(object id)
        {
            TEntity entityToDelete = this.ObtenerPorId(id);
            this.Eliminar(entityToDelete);
        }

        public void Eliminar(TEntity entityToDelete)
        {
            Attach(entityToDelete);
            this.dbSet.Remove(entityToDelete);
        }

        public void Actualizar(TEntity entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Attach(TEntity entity)
        {
            this.dbSet.Attach(entity);
        }

        public IEnumerable<TEntity> ObtenerElementosPaginados<TKey>(
            int pageIndex,
            int pageCount,
            Expression<Func<TEntity, TKey>> ordenarPorExpresion,
            bool ascendente = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> ObtenerElementosPaginados<TKey>(
            int pageIndex,
            int pageCount,
            Expression<Func<TEntity, TKey>> ordenarPorExpresion,
            bool ascendente = true,
            params Expression<Func<TEntity, object>>[] incluidos)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> ObtenerDesdeBasededatosConQuery(string sqlQuery, params object[] parametros)
        {
            throw new NotImplementedException();
        }

        public int EjecutarEnBasededatosPorQuery(string sqlCommand, params object[] parametros)
        {
            throw new NotImplementedException();
        }
    }
}