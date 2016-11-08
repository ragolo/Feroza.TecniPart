// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICatalogosRespositorio.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the ICatalogosRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using Entidades.Modelos;

    using Repositorio;

    /// <summary>
    /// The CatalogosRespositorio interface.
    /// </summary>
    public interface ICatalogosRespositorio : IRepository<Catalogos>
    {
    }
}
