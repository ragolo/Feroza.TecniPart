// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnidadDeTrabajo.cs" company="">
//   
// </copyright>
// <summary>
//   The UnidadDeTrabajo interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.RepositorioContratos
{
    /// <summary>The UnidadDeTrabajo interface.</summary>
    public interface IUnidadDeTrabajo
    {
        /// <summary>
        /// Confirmar sobre la base de datos. Si hay un problema de concurrencia lanzará una excepción
        /// </summary>
        void Confirmar();

        /// <summary>
        /// Confirmar sobre la base de datos. Si hay un problema de concurrencia "refrescará" los datos del cliente. Aproximación "Client wins"
        /// </summary>
        void ConfirmarYRefrescarCambios();

        /// <summary>
        /// Revertir los cambios que se han producido en la Unit of Work y que están siendo observados por ella
        /// </summary>
        void Revertir();
    }
}