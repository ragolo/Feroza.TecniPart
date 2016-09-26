// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculosController.cs" company="Feroza">
//   The Feroza 2016
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Api.Administracion
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Feroza.TecniPart.Dominio.Entidades.Modelos;
    using Feroza.TecniPart.Dominio.Interfaces.Administracion;

    /// <summary>
    /// The estado maestras controller.
    /// </summary>
    public class VehiculosController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IVehiculosServicio vehiculosServicios;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehiculosController"/> class.
        /// </summary>
        /// <param name="vehiculosServicios">
        /// The estado maestras servicios.
        /// </param>
        public VehiculosController(IVehiculosServicio vehiculosServicios)
        {
            this.vehiculosServicios = vehiculosServicios;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        [HttpGet]
        public Vehiculos Get(int id)
        {
            return this.vehiculosServicios.ListVehiculos(id).FirstOrDefault();
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<Vehiculos> Get()
        {
            return this.vehiculosServicios.ListVehiculos();
        }

        /// <summary>The post estado maestras.</summary>
        /// <param name="estadoMaestra">The estado maestra.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostVehiculos(Vehiculos vehiculos)
        {
            var vehiculosResult = this.vehiculosServicios.AddVehiculos(vehiculos);
            return this.Ok(vehiculosResult);
        }

        [HttpPut]
        public IHttpActionResult PutVehiculos(Vehiculos estadoMaestra)
        {
            var vehiculos = this.vehiculosServicios.EditVehiculos(estadoMaestra);
            return this.Ok(vehiculos);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        [HttpDelete]
        public void Delete(int id)
        {
            this.vehiculosServicios.DeleteVehiculos(id);
        }
    }
}