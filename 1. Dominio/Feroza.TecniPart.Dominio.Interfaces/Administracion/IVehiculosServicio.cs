// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVehiculosServicio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The VehiculosServicio interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The VehiculosServicio interface.
    /// </summary>
    public interface IVehiculosServicio
    {
        /// <summary>Adds the estado maestras.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="Vehiculos"/>.</returns>
        Vehiculos AddVehiculos(Vehiculos pais);

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="Vehiculos"/>.</returns>
        Vehiculos EditVehiculos(Vehiculos pais);

        /// <summary>
        /// Deletes the estado maestras.
        /// </summary>
        /// <param name="idVehiculos">The identifier estado maestras.</param>
        void DeleteVehiculos(int idVehiculos);

        /// <summary>
        /// Lists the estado maestras.
        /// </summary>
        /// <param name="idVehiculos">The identifier estado maestras.</param>
        /// <returns>list of the Vehiculos</returns>
        IEnumerable<Vehiculos> ListVehiculos(int idVehiculos);

        /// <summary>The list estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Vehiculos/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Vehiculos> ListVehiculos();
    }
}