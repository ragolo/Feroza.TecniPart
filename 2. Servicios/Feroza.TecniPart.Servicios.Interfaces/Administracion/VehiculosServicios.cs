﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculosServicios.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the EstadoMaestrasServicios type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Administracion
{
    using System.Collections.Generic;
    using System.Linq;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Extensions;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class VehiculosServicios : IVehiculosServicio
    {
        /// <summary>
        /// The estado maestras repositorio.
        /// </summary>
        private readonly IVehiculosRespositorio vehiculosRespositorio;

        /// <summary>Initializes a new instance of the <see cref="VehiculosServicios"/> class.</summary>
        /// <param name="vehiculosRepositorio">The vehiculos repositorio.</param>
        public VehiculosServicios(IVehiculosRespositorio vehiculosRepositorio)
        {
            this.vehiculosRespositorio = vehiculosRepositorio;
        }

        /// <summary>The add vehiculos.</summary>
        /// <param name="vehiculos">The vehiculos.</param>
        public Vehiculos AddVehiculos(Vehiculos vehiculos)
        {
            return this.vehiculosRespositorio.Crear(vehiculos);
        }

        /// <summary>The edit vehiculos.</summary>
        /// <param name="vehiculos">The vehiculos.</param>
        /// <returns>The <see cref="Vehiculos"/>.</returns>
        public Vehiculos EditVehiculos(Vehiculos vehiculos)
        {
            return this.vehiculosRespositorio.Editar(vehiculos);
        }

        /// <summary>The delete vehiculos.</summary>
        /// <param name="idVehiculos">The id vehiculos.</param>
        public void DeleteVehiculos(int idVehiculos)
        {
            this.vehiculosRespositorio.Eliminar(idVehiculos);
        }

        /// <summary>The list vehiculos.</summary>
        /// <param name="idVehiculos">The id vehiculos.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Vehiculos> ListVehiculos(int idVehiculos)
        {
            var vehiculos = this.vehiculosRespositorio.ListarVehiculos(idVehiculos);

            return vehiculos;
        }

        /// <summary>The list vehiculos.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Vehiculos> ListVehiculos()
        {
            var vehiculos = this.vehiculosRespositorio.ListarVehiculoses();

            return vehiculos;
        }
    }
}