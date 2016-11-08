// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SistemasController.cs" company="">
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
    public class SistemasController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly ISistemasServicio sistemasServicios;


        /// <summary>Initializes a new instance of the <see cref="SistemasController"/> class.</summary>
        /// <param name="sistemasServicios">The estado maestras servicios.</param>
        /// <param name="managementImageFacade">The management Image Facade.</param>
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
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostSistemas(Sistemas id)
        {
            this.sistemasServicios.Add(id);
            return this.Ok(id);
        }

        /// <summary>The put sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPut]
        public async Task<IHttpActionResult> PutSistemas(Sistemas sistemas)
        {
            try
            {
                this.sistemasServicios.Edit(sistemas);
                return this.Ok(sistemas);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>The delete.</summary>
        /// <param name="sistemas">The sistemas.</param>
        [HttpDelete]
        public void Delete(Sistemas sistemas)
        {
            this.sistemasServicios.Delete(sistemas);
        }
    }
}