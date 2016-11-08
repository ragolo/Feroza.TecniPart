// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SistemasController.cs" company="Feroza">
//   The Feroza 2016
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Administracion
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>The sistemas controller.</summary>
    //[Authorize]
    public class SistemasController : ApiController
    {
        /// <summary>The sistemas servicios.</summary>
        private readonly ISistemasServicio sistemasServicios;

        /// <summary>Initializes a new instance of the <see cref="SistemasController"/> class.</summary>
        /// <param name="sistemasServicios">The sistemas servicios.</param>
        public SistemasController(ISistemasServicio sistemasServicios)
        {
            this.sistemasServicios = sistemasServicios;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Sistemas"/>.</returns>
        [HttpGet]
        public Sistemas Get(int id)
        {
            return this.sistemasServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        [HttpGet]
        public IEnumerable<Sistemas> Get()
        {
            return this.sistemasServicios.List();
        }

        /// <summary>The post sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostSistemas(Sistemas sistemas)
        {
            this.sistemasServicios.Add(sistemas);
            return this.Ok(sistemas);
        }

        /// <summary>The put sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult PutSistemas(Sistemas sistemas)
        {
            this.sistemasServicios.Edit(sistemas);
            return this.Ok(sistemas);
        }

        /// <summary>The delete.</summary>
        /// <param name="sistemas"></param>
        [HttpDelete]
        public void Delete(Sistemas sistemas)
        {
            this.sistemasServicios.Delete(sistemas);
        }
    }
}