// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FabricantesController.cs" company="Feroza">
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


        /// <summary>Initializes a new instance of the <see cref="FabricantesController"/> class.</summary>
        /// <param name="fabricantesServicios">The estado maestras servicios.</param>
        /// <param name="managementImageFacade">The management Image Facade.</param>
        public FabricantesController(IFabricantesServicio fabricantesServicios)
        {
            this.fabricantesServicios = fabricantesServicios;
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
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostFabricantes(Fabricantes id)
        {
            this.fabricantesServicios.Add(id);
            return this.Ok(id);
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
    }
}