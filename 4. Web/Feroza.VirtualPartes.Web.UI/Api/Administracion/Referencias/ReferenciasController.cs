// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenciasController.cs" company="">
//   
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Administracion.Referencias
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Dominio.Entidades.Modelos.Referencias;
    using Dominio.Interfaces.Administracion.Referencias;

    /// <summary>
    /// The estado maestras controller.
    /// </summary>
    //[Authorize]
    public class ReferenciasController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IReferenciasServicio lineasProductosServicios;


        /// <summary>Initializes a new instance of the <see cref="ReferenciasController"/> class.</summary>
        /// <param name="lineasProductosServicios">The estado maestras servicios.</param>
        public ReferenciasController(IReferenciasServicio lineasProductosServicios)
        {
            this.lineasProductosServicios = lineasProductosServicios;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Referencias"/>.</returns>
        [HttpGet]
        public Referencias Get(int id)
        {
            return this.lineasProductosServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        [HttpGet]
        public IEnumerable<Referencias> Get()
        {
            return this.lineasProductosServicios.List();
        }

        /// <summary>The post lineasProductos.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostReferencias(Referencias id)
        {
            id.ReferenciaVP = id.CodigoOEM;
            this.lineasProductosServicios.Add(id);
            return this.Ok(id);
        }

        /// <summary>The put lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        public async Task<IHttpActionResult> PutReferencias(Referencias lineasProductos)
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
        public void Delete(Referencias lineasProductos)
        {
            this.lineasProductosServicios.Delete(lineasProductos);
        }
    }
}