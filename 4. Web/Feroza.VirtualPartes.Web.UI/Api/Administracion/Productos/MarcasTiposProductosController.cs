// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasTiposProductosController.cs" company="">
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
    public class MarcasTiposProductosController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IMarcasTiposProductosServicio marcasTiposProductosServicios;

        /// <summary>Initializes a new instance of the <see cref="MarcasTiposProductosController"/> class.</summary>
        /// <param name="marcasTiposProductosServicios">The estado maestras servicios.</param>
        public MarcasTiposProductosController(IMarcasTiposProductosServicio marcasTiposProductosServicios)
        {
            this.marcasTiposProductosServicios = marcasTiposProductosServicios;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="MarcasTiposProductos"/>.</returns>
        [HttpGet]
        public MarcasTiposProductos Get(int id)
        {
            return this.marcasTiposProductosServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        [HttpGet]
        public IEnumerable<MarcasTiposProductos> Get()
        {
            return this.marcasTiposProductosServicios.List();
        }

        /// <summary>The post marcasTiposProductos.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostMarcasTiposProductos(MarcasTiposProductos id)
        {
            this.marcasTiposProductosServicios.Add(id);
            return this.Ok(id);
        }

        /// <summary>The put marcasTiposProductos.</summary>
        /// <param name="marcasTiposProductos">The marcasTiposProductos.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        public async Task<IHttpActionResult> PutMarcasTiposProductos(MarcasTiposProductos marcasTiposProductos)
        {
            try
            {
                this.marcasTiposProductosServicios.Edit(marcasTiposProductos);
                return this.Ok(marcasTiposProductos);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>The delete.</summary>
        /// <param name="marcasTiposProductos">The marcasTiposProductos.</param>
        [HttpDelete]
        public void Delete(MarcasTiposProductos marcasTiposProductos)
        {
            this.marcasTiposProductosServicios.Delete(marcasTiposProductos);
        }
    }
}