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

    using Feroza.TecniPart.Dominio.Entidades.Modelos;
    using Feroza.TecniPart.Dominio.Interfaces.Administracion;

    /// <summary>
    /// The estado maestras controller.
    /// </summary>
    public class PaisController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IPaisServicio paisServicios;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaisController"/> class.
        /// </summary>
        /// <param name="paisServicios">
        /// The estado maestras servicios.
        /// </param>
        public PaisController(IPaisServicio paisServicios)
        {
            this.paisServicios = paisServicios;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="idPais">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        [HttpGet]
        public Pais Get(int idPais)
        {
            return this.paisServicios.ListPais(idPais).FirstOrDefault();
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

        /// <summary>The post estado maestras.</summary>
        /// <param name="estadoMaestra">The estado maestra.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostPais(Pais pais)
        {
            var paisResult = this.paisServicios.AddPais(pais);
            return this.Ok(paisResult);
        }

        [HttpPut]
        public IHttpActionResult PutPais(Pais estadoMaestra)
        {
            var pais = this.paisServicios.EditPais(estadoMaestra);
            return this.Ok(pais);
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