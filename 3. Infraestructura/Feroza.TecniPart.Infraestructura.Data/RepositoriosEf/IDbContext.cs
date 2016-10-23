namespace Feroza.TecniPart.Infraestructura.Data.RepositoriosEf
{
    using System;
    using System.Data.Entity;

    public interface IDbContext : IDisposable
    {
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : class;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : class;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

    }
}
