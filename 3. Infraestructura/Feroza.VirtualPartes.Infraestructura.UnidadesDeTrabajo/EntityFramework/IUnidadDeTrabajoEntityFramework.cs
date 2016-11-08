// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnidadDeTrabajoEntityFramework.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IUnidadDeTrabajoEntityFramework type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.UnidadesDeTrabajo.EntityFramework
{
    using System.Collections.Generic;
    using System.Data.Entity;

    using Dominio.RepositorioContratos;

    /// <summary>The UnidadDeTrabajoEntityFramework interface.</summary>
    public interface IUnidadDeTrabajoEntityFramework : IUnidadDeTrabajo
    {
        /// <summary>The set.</summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="IDbSet"/>.</returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>The attach.</summary>
        /// <param name="item">The item.</param>
        /// <typeparam name="TEntity"></typeparam>
        void Attach<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>The set modified.</summary>
        /// <param name="item">The item.</param>
        /// <typeparam name="TEntity"></typeparam>
        void SetModified<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>The execute query.</summary>
        /// <param name="sqlQuery">The sql query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);

        /// <summary>The execute command.</summary>
        /// <param name="sqlCommand">The sql command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The <see cref="int"/>.</returns>
        int ExecuteCommand(string sqlCommand, params object[] parameters);
    }
}