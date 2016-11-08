// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnidadDeTrabajoReferencias.cs" company="">
//   
// </copyright>
// <summary>
//   The UnidadDeTrabajoReferencias interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Interfaces.Administracion.Referencias
{
    using Entidades.Modelos.Referencias;

    using RepositorioContratos;

    /// <summary>The UnidadDeTrabajoReferencias interface.</summary>
    public interface IUnidadDeTrabajoReferencias : IUnidadDeTrabajo
    {
        /// <summary>Gets the referencias repositorio.</summary>
        IRepositorio<Referencias> ReferenciasRepositorio { get; }

        /// <summary>Gets the consecutivos paises oem repositorio.</summary>
        IRepositorio<ConsecutivosPaisesOEM> ConsecutivosPaisesOemRepositorio { get; }
    }
}