namespace Feroza.VirtualPartes.Dominio.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>The Servicio interface.</summary>
    /// <typeparam name="TEntidad"></typeparam>
    public interface IServicio<TEntidad>
    {
        /// <summary>The add.</summary>
        /// <param name="entidad">The entidad.</param>
        void Add(TEntidad entidad);

        /// <summary>The edit TEntidad.</summary>
        /// <param name="entidad">The TEntidad.</param>
        void Edit(TEntidad entidad);

        /// <summary>The delete TEntidad.</summary>
        /// <param name="entidad">The entidad.</param>
        void Delete(TEntidad entidad);

        /// <summary>The get TEntidad.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="TEntidad"/>.</returns>
        TEntidad Get(int id);

        /// <summary>The list.</summary>
        /// <returns>The <see cref="IList"/>.</returns>
        IList<TEntidad> List();

        /// <summary>The list TEntidad filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="TEntidad"/>.</returns>
        IList<TEntidad> ListFiltered(Expression<Func<TEntidad, bool>> filter);
    }
}