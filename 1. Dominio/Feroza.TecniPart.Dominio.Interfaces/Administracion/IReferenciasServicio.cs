// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReferenciasServicio.cs" company="">
//   
// </copyright>
// <summary>
//   The ReferenciasServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using Entidades.Modelos;

    /// <summary>The ReferenciasServicio interface.</summary>
    public interface IReferenciasServicio : IServicio<Referencias>
    {
        Referencias Get(string idReferencias);
    }
}