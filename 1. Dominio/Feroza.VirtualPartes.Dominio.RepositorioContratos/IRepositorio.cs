namespace Feroza.VirtualPartes.Dominio.RepositorioContratos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepositorio<TEntity>
    {
        IEnumerable<TEntity> Obtener(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] incluidos);

        IEnumerable<TEntity> ObtenerTodo();

        TEntity ObtenerPorId(object id);

        void Insertar(TEntity entity);

        void Eliminar(object id);

        void Eliminar(TEntity entityToDelete);

        void Actualizar(TEntity entityToUpdate);

        IEnumerable<TEntity> ObtenerElementosPaginados<TKey>(int pageIndex, int pageCount, Expression<Func<TEntity, TKey>> ordenarPorExpresion, bool ascendente = true);

        IEnumerable<TEntity> ObtenerElementosPaginados<TKey>(int pageIndex, int pageCount, Expression<Func<TEntity, TKey>> ordenarPorExpresion, bool ascendente = true, params Expression<Func<TEntity, object>>[] incluidos);

        IEnumerable<TEntity> ObtenerDesdeBasededatosConQuery(string sqlQuery, params object[] parametros);

        int EjecutarEnBasededatosPorQuery(string sqlCommand, params object[] parametros);
    }
}
