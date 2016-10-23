namespace Feroza.TecniPart.Infraestructura.Data.RepositoriosEf.Extensions
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>The general extensions.</summary>
    public static class GeneralExtensions
    {
        /// <summary>The include multiple.</summary>
        /// <param name="query">The query.</param>
        /// <param name="includes">The includes.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include).AsNoTracking());
            }

            return query;
        }
    }
}
