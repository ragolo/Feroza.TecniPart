// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnidadDeTrabajo.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IUnidadDeTrabajo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Interfaces.Repositorios
{
    using System;

    /// <summary>The UnidadDeTrabajo interface.</summary>
    public interface IUnidadDeTrabajo : IDisposable
    {
        //Commit sobre la base de datos. Si hay un problema de concurrencia lanzará una excepción
        void Commit();
        //Commit sobre la base de datos. Si hay un problema de concurrencia "refrescará" los datos del cliente. Aproximación "Client wins"
        void CommitAndRefreshChanges();
        //Rollback de los cambios que se han producido en la Unit of Work y que están siendo observados por ella
        void Rollback();
    }
}
