// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculosController.cs" company="Feroza">
//   The Feroza 2016
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Facade;

    using Models;

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
        /// The management image facade
        /// </summary>
        private readonly IManagementImageFacade<Vehiculos> managementImageFacade;

        /// <summary>Initializes a new instance of the <see cref="VehiculosController"/> class.</summary>
        /// <param name="vehiculosServicios">The vehiculos servicios.</param>
        /// <param name="managementImageFacade">The management image facade.</param>
        public VehiculosController(IVehiculosServicio vehiculosServicios, IManagementImageFacade<Vehiculos> managementImageFacade)
        {
            this.vehiculosServicios = vehiculosServicios;
            this.managementImageFacade = managementImageFacade;
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
            return this.vehiculosServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<Vehiculos> Get()
        {
            return this.vehiculosServicios.List();
        }

        /// <summary>The post estado maestras.</summary>
        /// <param name="vehiculos">The vehiculos.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostVehiculos(Vehiculos vehiculos)
        {
            this.vehiculosServicios.Add(vehiculos);
            return this.Ok(vehiculos);
        }

        /// <summary>The post vehiculos.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        [RouteAttribute("Api/VehiculosImage")]
        public async Task<IHttpActionResult> PostVehiculos()
        {
            var entityWithImageModel = await this.MappingImageToEntity();
            this.vehiculosServicios.Add(entityWithImageModel.EntityModel);
            return this.Ok(entityWithImageModel.EntityModel);
        }

        [HttpPut]
        [RouteAttribute("Api/VehiculosImage")]
        public async Task<IHttpActionResult> PutVehiculos()
        {
            try
            {
                var entityWithImageModel = await this.MappingImageToEntity();
                this.vehiculosServicios.Edit(entityWithImageModel.EntityModel);
                return this.Ok(entityWithImageModel.EntityModel);

            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>The put vehiculos.</summary>
        /// <param name="vehiculos">The vehiculos.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult PutVehiculos(Vehiculos vehiculos)
        {
            this.vehiculosServicios.Edit(vehiculos);
            return this.Ok(vehiculos);
        }

        /// <summary>The delete.</summary>
        /// <param name="vehiculos"></param>
        [HttpDelete]
        public void Delete(Vehiculos vehiculos)
        {
            this.vehiculosServicios.Delete(vehiculos);
        }

        /// <summary>The mapping image to entity.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task<EntityWithImageModel<Vehiculos>> MappingImageToEntity()
        {
            var entityWithImageModel = await this.managementImageFacade.GetEntityWithImage("~/App_Data/Temp/FileUploads", this.Request.Content);
            entityWithImageModel.EntityModel.ImagenVehiculo = entityWithImageModel.FileDescription.ImageBytes;
            return entityWithImageModel;
        }
    }
}