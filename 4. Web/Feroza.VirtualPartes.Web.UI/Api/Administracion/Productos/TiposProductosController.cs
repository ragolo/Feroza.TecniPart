// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TiposProductosController.cs" company="">
//   
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Administracion.Productos
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Dominio.Entidades.Modelos.Productos;
    using Dominio.Interfaces.Administracion.Productos;

    /// <summary>
    /// The estado maestras controller.
    /// </summary>
    //[Authorize]
    public class TiposProductosController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly ITiposProductosServicio tiposProductosServicios;


        /// <summary>Initializes a new instance of the <see cref="TiposProductosController"/> class.</summary>
        /// <param name="tiposProductosServicios">The estado maestras servicios.</param>
        /// <param name="managementImageFacade">The management Image Facade.</param>
        public TiposProductosController(ITiposProductosServicio tiposProductosServicios)
        {
            this.tiposProductosServicios = tiposProductosServicios;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="TiposProductos"/>.</returns>
        [HttpGet]
        public TiposProductos Get(int id)
        {
            return this.tiposProductosServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        [HttpGet]
        public IEnumerable<TiposProductos> Get()
        {
            return this.tiposProductosServicios.List();
        }

        /// <summary>The post tiposProductos.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostTiposProductos(TiposProductos id)
        {
            this.tiposProductosServicios.Add(id);
            return this.Ok(id);
        }

        /// <summary>The put tiposProductos.</summary>
        /// <param name="tiposProductos">The tiposProductos.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        public async Task<IHttpActionResult> PutTiposProductos(TiposProductos tiposProductos)
        {
            try
            {
                this.tiposProductosServicios.Edit(tiposProductos);
                return this.Ok(tiposProductos);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>The delete.</summary>
        /// <param name="tiposProductos">The tiposProductos.</param>
        [HttpDelete]
        public void Delete(TiposProductos tiposProductos)
        {
            this.tiposProductosServicios.Delete(tiposProductos);
        }
    }
}