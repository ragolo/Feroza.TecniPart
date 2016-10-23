// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenciasController.cs" company="Feroza">
//   The Feroza 2016
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Api.Administracion
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The estado maestras controller.
    /// </summary>
    //[Authorize]
    public class ReferenciasController : ApiController
    {
        /// <summary>The referencias servicios.</summary>
        private readonly IReferenciasServicio referenciasServicios;

        /// <summary>Initializes a new instance of the <see cref="ReferenciasController"/> class.</summary>
        /// <param name="referenciasServicios">The referencias servicios.</param>
        public ReferenciasController(IReferenciasServicio referenciasServicios)
        {
            this.referenciasServicios = referenciasServicios;
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
        public Referencias Get(int id)
        {
            return this.referenciasServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<Referencias> Get()
        {
            return this.referenciasServicios.List();
        }

        /// <summary>The post referencias.</summary>
        /// <param name="referencias">The referencias.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostReferencias(Referencias referencias)
        {
            this.referenciasServicios.Add(referencias);
            return this.Ok(referencias);
        }

        /// <summary>The put referencias.</summary>
        /// <param name="referencias">The referencias.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult PutReferencias(Referencias referencias)
        {
            this.referenciasServicios.Edit(referencias);
            return this.Ok(referencias);
        }

        /// <summary>The delete.</summary>
        /// <param name="referencias">The referencias.</param>
        [HttpDelete]
        public void Delete(Referencias referencias)
        {
            this.referenciasServicios.Delete(referencias);
        }
    }
}