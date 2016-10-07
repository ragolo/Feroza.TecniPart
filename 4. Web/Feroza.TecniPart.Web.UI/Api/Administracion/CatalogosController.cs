// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogosController.cs" company="Feroza">
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
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Facade;

    using Models;

    /// <summary>
    /// The estado maestras controller.
    /// </summary>
    public class CatalogosController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly ICatalogosServicio catalogosServicios;

        /// <summary>The management image facade.</summary>
        private readonly IManagementImageFacade<Catalogos> managementImageFacade;


        /// <summary>Initializes a new instance of the <see cref="CatalogosController"/> class.</summary>
        /// <param name="catalogosServicios">The estado maestras servicios.</param>
        /// <param name="managementImageFacade">The management Image Facade.</param>
        public CatalogosController(
            ICatalogosServicio catalogosServicios,
            IManagementImageFacade<Catalogos> managementImageFacade)
        {
            this.catalogosServicios = catalogosServicios;
            this.managementImageFacade = managementImageFacade;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Catalogos"/>.</returns>
        [HttpGet]
        public Catalogos Get(int id)
        {
            return this.catalogosServicios.ListCatalogos(id).FirstOrDefault();
        }

        /// <summary>The get.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        [HttpGet]
        public IEnumerable<Catalogos> Get()
        {
            return this.catalogosServicios.ListCatalogos();
        }

        /// <summary>The post catalogos.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        [RouteAttribute("Api/CatalogosImage")]
        public async Task<IHttpActionResult> PostCatalogos()
        {
            var entityWithImageModel = await this.MappingImageToEntity();
            var catalogosResult = this.catalogosServicios.AddCatalogos(entityWithImageModel.EntityModel);
            return this.Ok(catalogosResult);
        }

        /// <summary>The post catalogos.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostCatalogos(Catalogos id)
        {
            var catalogosResult = this.catalogosServicios.AddCatalogos(id);
            return this.Ok(catalogosResult);
        }

        /// <summary>The put catalogos.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        [RouteAttribute("Api/CatalogosImage")]
        public async Task<IHttpActionResult> PutCatalogos()
        {
            try
            {
                var entityWithImageModel = await this.MappingImageToEntity();
                var catalogoResult = this.catalogosServicios.EditCatalogos(entityWithImageModel.EntityModel);
                return this.Ok(catalogoResult);

            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>The put catalogos.</summary>
        /// <param name="catalogos">The catalogos.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        public async Task<IHttpActionResult> PutCatalogos(Catalogos catalogos)
        {
            try
            {
                var catalogoResult = this.catalogosServicios.EditCatalogos(catalogos);
                return this.Ok(catalogoResult);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
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
            this.catalogosServicios.DeleteCatalogos(id);
        }

        /// <summary>The mapping image to entity.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task<EntityWithImageModel<Catalogos>> MappingImageToEntity()
        {
            var entityWithImageModel = await this.managementImageFacade.GetEntityWithImage("~/App_Data/Temp/FileUploads", this.Request.Content);
            entityWithImageModel.EntityModel.ImagenCatalogo = entityWithImageModel.FileDescription.ImageBytes;
            return entityWithImageModel;
        }
    }
}