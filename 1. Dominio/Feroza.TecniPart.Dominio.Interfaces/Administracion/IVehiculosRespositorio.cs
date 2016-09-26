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
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The VehiculosRespositorio interface.
    /// </summary>
    public interface IVehiculosRespositorio
    {
        /// <summary>Crears the specified descripcion.</summary>
        /// <param name="pais"></param>
        /// <returns>The <see cref="Vehiculos"/>.</returns>
        Vehiculos Crear(Vehiculos pais);

        /// <summary>The editar.</summary>
        /// <param name="pais"></param>
        /// <returns>The <see cref="Vehiculos"/>.</returns>
        Vehiculos Editar(Vehiculos pais);

        /// <summary>
        /// Eliminars the specified identifier estado maestras.
        /// </summary>
        /// <param name="idVehiculos">The identifier estado maestras.</param>
        void Eliminar(int idVehiculos);

        /// <summary>The listar estado maestras.</summary>
        /// <param name="idVehiculos">The id estado maestras.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Vehiculos/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Vehiculos> ListarVehiculos(int idVehiculos);

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Vehiculos/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Vehiculos> ListarVehiculoses();
    }
}
