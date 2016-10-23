// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FabricantesController.cs" company="Feroza">
//   The Feroza 2016
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Api.Administracion
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
    //[Authorize]
    public class FabricantesController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IFabricantesServicio fabricantesServicios;

        /// <summary>The management image facade.</summary>
        private readonly IManagementImageFacade<Fabricantes> managementImageFacade;


        /// <summary>Initializes a new instance of the <see cref="FabricantesController"/> class.</summary>
        /// <param name="fabricantesServicios">The estado maestras servicios.</param>
        /// <param name="managementImageFacade">The management Image Facade.</param>
        public FabricantesController(
            IFabricantesServicio fabricantesServicios,
            IManagementImageFacade<Fabricantes> managementImageFacade)
        {
            this.fabricantesServicios = fabricantesServicios;
            this.managementImageFacade = managementImageFacade;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Fabricantes"/>.</returns>
        [HttpGet]
        public Fabricantes Get(int id)
        {
            return this.fabricantesServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        [HttpGet]
        public IEnumerable<Fabricantes> Get()
        {
            return this.fabricantesServicios.List();
        }

        /// <summary>The post fabricantes.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        [RouteAttribute("Api/FabricantesImage")]
        public async Task<IHttpActionResult> PostFabricantes()
        {
            var entityWithImageModel = await this.MappingImageToEntity();
            this.fabricantesServicios.Add(entityWithImageModel.EntityModel);
            return this.Ok(entityWithImageModel.EntityModel);
        }

        /// <summary>The post fabricantes.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostFabricantes(Fabricantes id)
        {
            this.fabricantesServicios.Add(id);
            return this.Ok(id);
        }

        /// <summary>The put fabricantes.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        [RouteAttribute("Api/FabricantesImage")]
        public async Task<IHttpActionResult> PutFabricantes()
        {
            try
            {
                var entityWithImageModel = await this.MappingImageToEntity();
                this.fabricantesServicios.Edit(entityWithImageModel.EntityModel);
                return this.Ok(entityWithImageModel.EntityModel);

            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>The put fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        public async Task<IHttpActionResult> PutFabricantes(Fabricantes fabricantes)
        {
            try
            {
                this.fabricantesServicios.Edit(fabricantes);
                return this.Ok(fabricantes);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>The delete.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        [HttpDelete]
        public void Delete(Fabricantes fabricantes)
        {
            this.fabricantesServicios.Delete(fabricantes);
        }

        /// <summary>The mapping image to entity.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task<EntityWithImageModel<Fabricantes>> MappingImageToEntity()
        {
            var entityWithImageModel = await this.managementImageFacade.GetEntityWithImage("~/App_Data/Temp/FileUploads", this.Request.Content);
            entityWithImageModel.EntityModel.ImagenFabricante = entityWithImageModel.FileDescription.ImageBytes;
            return entityWithImageModel;
        }
    }
}