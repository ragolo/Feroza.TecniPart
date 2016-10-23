// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubSistemasController.cs" company="Feroza">
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

    /// <summary>The sistemas controller.</summary>
    //[Authorize]
    public class SubSistemasController : ApiController
    {
        /// <summary>The sistemas servicios.</summary>
        private readonly ISubSistemasServicio sistemasServicios;

        /// <summary>Initializes a new instance of the <see cref="SubSistemasController"/> class.</summary>
        /// <param name="sistemasServicios">The sistemas servicios.</param>
        public SubSistemasController(ISubSistemasServicio sistemasServicios)
        {
            this.sistemasServicios = sistemasServicios;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="SubSistemas"/>.</returns>
        [HttpGet]
        public SubSistemas Get(int id)
        {
            return this.sistemasServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        [HttpGet]
        public IEnumerable<SubSistemas> Get()
        {
            return this.sistemasServicios.List();
        }

        /// <summary>The post sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostSubSistemas(SubSistemas sistemas)
        {
            this.sistemasServicios.Add(sistemas);
            return this.Ok(sistemas);
        }

        /// <summary>The put sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult PutSubSistemas(SubSistemas sistemas)
        {
            this.sistemasServicios.Edit(sistemas);
            return this.Ok(sistemas);
        }

        /// <summary>The delete.</summary>
        /// <param name="subSistemas">The sub Sistemas.</param>
        [HttpDelete]
        public void Delete(SubSistemas subSistemas)
        {
            this.sistemasServicios.Delete(subSistemas);
        }
    }
}