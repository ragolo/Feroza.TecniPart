// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVehiculosRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the IVehiculosRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using Entidades.Modelos;

    using Repositorio;

    /// <summary>
    /// The VehiculosRespositorio interface.
    /// </summary>
    public interface IVehiculosRespositorio : IRepository<Vehiculos>
    {
    }
}
