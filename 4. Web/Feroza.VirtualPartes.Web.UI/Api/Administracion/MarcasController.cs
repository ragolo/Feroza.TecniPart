// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasController.cs" company="Feroza">
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

    /// <summary>
    /// The estado maestras controller.
    /// </summary>
    //[Authorize]
    public class MarcasController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IMarcasServicio marcasServicios;

        /// <summary>Initializes a new instance of the <see cref="MarcasController"/> class.</summary>
        /// <param name="marcasServicios">The marcas servicios.</param>
        public MarcasController(IMarcasServicio marcasServicios)
        {
            this.marcasServicios = marcasServicios;
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
        public Marcas Get(int id)
        {
            return this.marcasServicios.Get(id);
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<Marcas> Get()
        {
            return this.marcasServicios.List();
        }

        /// <summary>The post marcas.</summary>
        /// <param name="marcas">The marcas.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostMarcas(Marcas marcas)
        {
            this.marcasServicios.Add(marcas);
            return this.Ok(marcas);
        }

        /// <summary>The put marcas.</summary>
        /// <param name="marcas">The marcas.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult PutMarcas(Marcas marcas)
        {
            this.marcasServicios.Edit(marcas);
            return this.Ok(marcas);
        }

        /// <summary>The delete.</summary>
        /// <param name="marcas">The marcas.</param>
        [HttpDelete]
        public void Delete(Marcas marcas)
        {
            this.marcasServicios.Delete(marcas);
        }
    }
}