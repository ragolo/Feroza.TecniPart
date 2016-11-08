// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnidadDeTrabajoAdministracion.cs" company="">
//   
// </copyright>
// <summary>
//   The UnidadDeTrabajoProductos interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Interfaces.Administracion
{
    using Entidades.Modelos;
    using RepositorioContratos;

    /// <summary>The UnidadDeTrabajoProductos interface.</summary>
    public interface IUnidadDeTrabajoAdministracion : IUnidadDeTrabajo
    {
        /// <summary>Gets the paises repositorio.</summary>
        IRepositorio<Paises> PaisesRepositorio { get; }

        /// <summary>Gets the fabricantes repositorio.</summary>
        IRepositorio<Fabricantes> FabricantesRepositorio { get; }

        /// <summary>Gets the marcas repositorio.</summary>
        IRepositorio<Marcas> MarcasRepositorio { get; }
    }
}