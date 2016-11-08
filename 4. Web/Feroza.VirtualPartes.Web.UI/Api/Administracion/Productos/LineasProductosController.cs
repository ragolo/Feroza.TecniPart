// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineasProductosController.cs" company="">
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
    public class LineasProductosController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly ILineasProductosServicio lineasProductosServicios;


        /// <summary>Initializes a new instance of the <see cref="LineasProductosController"/> class.</summary>
        /// <param name="lineasProductosServicios">The estado maestras servicios.</param>
        /// <param name="managementImageFacade">The management Image Facade.</param>
        public LineasProductosController(ILineasProductosServicio lineasProductosServicios)
        {
            this.lineasProductosServicios = lineasProductosServicios;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="LineasProductos"/>.</returns>
        [HttpGet]
        public LineasProductos Get(int id)
        {
            return this.lineasProductosServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        [HttpGet]
        public IEnumerable<LineasProductos> Get()
        {
            return this.lineasProductosServicios.List();
        }

        /// <summary>The post lineasProductos.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostLineasProductos(LineasProductos id)
        {
            this.lineasProductosServicios.Add(id);
            return this.Ok(id);
        }

        /// <summary>The put lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        public async Task<IHttpActionResult> PutLineasProductos(LineasProductos lineasProductos)
        {
            try
            {
                this.lineasProductosServicios.Edit(lineasProductos);
                return this.Ok(lineasProductos);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>The delete.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        [HttpDelete]
        public void Delete(LineasProductos lineasProductos)
        {
            this.lineasProductosServicios.Delete(lineasProductos);
        }
    }
}