// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductosController.cs" company="">
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
    public class ProductosController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IProductosServicio productosServicios;


        /// <summary>Initializes a new instance of the <see cref="ProductosController"/> class.</summary>
        /// <param name="productosServicios">The estado maestras servicios.</param>
        /// <param name="managementImageFacade">The management Image Facade.</param>
        public ProductosController(IProductosServicio productosServicios)
        {
            this.productosServicios = productosServicios;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Productos"/>.</returns>
        [HttpGet]
        public Productos Get(int id)
        {
            return this.productosServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        [HttpGet]
        public IEnumerable<Productos> Get()
        {
            return this.productosServicios.List();
        }

        /// <summary>The post productos.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostProductos(Productos id)
        {
            this.productosServicios.Add(id);
            return this.Ok(id);
        }

        /// <summary>The put productos.</summary>
        /// <param name="productos">The productos.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        public async Task<IHttpActionResult> PutProductos(Productos productos)
        {
            try
            {
                this.productosServicios.Edit(productos);
                return this.Ok(productos);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>The delete.</summary>
        /// <param name="productos">The productos.</param>
        [HttpDelete]
        public void Delete(Productos productos)
        {
            this.productosServicios.Delete(productos);
        }
    }
}