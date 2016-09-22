// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductosController.cs" company="Feroza">
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
    public class ProductosController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IProductosServicio productosServicios;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductosController"/> class.
        /// </summary>
        /// <param name="productosServicios">
        /// The estado maestras servicios.
        /// </param>
        public ProductosController(IProductosServicio productosServicios)
        {
            this.productosServicios = productosServicios;
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
        public Productos Get(int id)
        {
            return this.productosServicios.ListProductos(id).FirstOrDefault();
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<Productos> Get()
        {
            return this.productosServicios.ListProductos();
        }

        /// <summary>The post estado maestras.</summary>
        /// <param name="estadoMaestra">The estado maestra.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostProductos(Productos productos)
        {
            var productosResult = this.productosServicios.AddProductos(productos);
            return this.Ok(productosResult);
        }

        [HttpPut]
        public IHttpActionResult PutProductos(Productos estadoMaestra)
        {
            var productos = this.productosServicios.EditProductos(estadoMaestra);
            return this.Ok(productos);
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
            this.productosServicios.DeleteProductos(id);
        }
    }
}