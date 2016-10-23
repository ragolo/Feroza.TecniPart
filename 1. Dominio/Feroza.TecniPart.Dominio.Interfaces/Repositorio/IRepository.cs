// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositorio.cs" company="">
//   
// </copyright>
// <summary>
//   The Repositorioy interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>The Repository interface.</summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>The get by id.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="T"/>.</returns>
        T GetById(object id);

        /// <summary>The insert.</summary>
        /// <param name="entity">The entity.</param>
        void Insert(T entity);

        /// <summary>The update.</summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>The delete.</summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>The get filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter);

        /// <summary>The get all with includes.</summary>
        /// <param name="includes">The includes.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
    }
}