// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaisController.cs" company="Feroza">
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

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>The pais controller.</summary>
    [Authorize]
    public class PaisController : ApiController
    {
        /// <summary>The pais servicios.</summary>
        private readonly IPaisServicio paisServicios;

        /// <summary>Initializes a new instance of the <see cref="PaisController"/> class.</summary>
        /// <param name="paisServicios">The pais servicios.</param>
        public PaisController(IPaisServicio paisServicios)
        {
            this.paisServicios = paisServicios;
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
        public Pais Get(int id)
        {
            return this.paisServicios.ListPais(id).FirstOrDefault();
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return this.paisServicios.ListPais();
        }

        /// <summary>The post pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostPais(Pais pais)
        {
            var paisResult = this.paisServicios.AddPais(pais);
            return this.Ok(paisResult);
        }

        /// <summary>The put pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult PutPais(Pais pais)
        {
            var paisResult = this.paisServicios.EditPais(pais);
            return this.Ok(paisResult);
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
            this.paisServicios.DeletePais(id);
        }
    }
}