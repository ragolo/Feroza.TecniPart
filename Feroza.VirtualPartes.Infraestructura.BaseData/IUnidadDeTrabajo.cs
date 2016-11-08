// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnidadDeTrabajo.cs" company="">
//   
// </copyright>
// <summary>
//   The UnidadDeTrabajo interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.BaseData
{
    using System;

    /// <summary>The UnidadDeTrabajo interface.</summary>
    public interface IUnidadDeTrabajo : IDisposable
    {
        /// <summary>The guardar.</summary>
        /// <returns>The <see cref="int"/>.</returns>
        int Guardar();

        /// <summary>Gets the contexto.</summary>
        IContexto Contexto { get; }
    }
}