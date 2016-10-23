// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaisController.cs" company="">
//   
// </copyright>
// <summary>
//   The pais controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Api.Administracion
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>The pais controller.</summary>
    //[Authorize]
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
            return this.paisServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return this.paisServicios.List();
        }

        /// <summary>The post pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostPais(Pais pais)
        {
            this.paisServicios.Add(pais);
            return this.Ok(pais);
        }

        /// <summary>The put pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult PutPais(Pais pais)
        {
            this.paisServicios.Edit(pais);
            return this.Ok(pais);
        }

        /// <summary>The delete.</summary>
        /// <param name="pais">The pais.</param>
        [HttpDelete]
        public void Delete(Pais pais)
        {
            this.paisServicios.Delete(pais);
        }
    }
}