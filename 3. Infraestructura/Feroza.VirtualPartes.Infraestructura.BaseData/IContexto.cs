// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDbContext.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IDbContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.BaseData
{
    using System;
    using System.Data.Entity;

    /// <summary>The DbContext interface.</summary>
    public interface IContexto : IDisposable
    {
        /// <summary>The asignar como agregado.</summary>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TEntity"></typeparam>
        void AsignarComoAgregado<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>The asignar como modificado.</summary>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TEntity"></typeparam>
        void AsignarComoModificado<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>The asignar como eliminar.</summary>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TEntity"></typeparam>
        void AsignarComoEliminar<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>The asignar.</summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="IDbSet"/>.</returns>
        IDbSet<TEntity> Asignar<TEntity>() where TEntity : class;

        /// <summary>The guardar cambios.</summary>
        /// <returns>The <see cref="int"/>.</returns>
        int GuardarCambios();
    }
}
