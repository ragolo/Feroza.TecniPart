// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFabricantesRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the IFabricantesRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using Entidades.Modelos;

    using Repositorio;

    /// <summary>
    /// The FabricantesRespositorio interface.
    /// </summary>
    public interface IFabricantesRespositorio : IRepository<Fabricantes>
    {
    }
}