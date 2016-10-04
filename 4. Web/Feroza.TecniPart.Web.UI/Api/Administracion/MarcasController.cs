// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasController.cs" company="Feroza">
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

    /// <summary>
    /// The estado maestras controller.
    /// </summary>
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
            return this.marcasServicios.ListMarcas(id).FirstOrDefault();
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<Marcas> Get()
        {
            return this.marcasServicios.ListMarcas();
        }

        /// <summary>The post marcas.</summary>
        /// <param name="marcas">The marcas.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostMarcas(Marcas marcas)
        {
            var marcasResult = this.marcasServicios.AddMarcas(marcas);
            return this.Ok(marcasResult);
        }

        /// <summary>The put marcas.</summary>
        /// <param name="estadoMaestra">The estado maestra.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult PutMarcas(Marcas estadoMaestra)
        {
            var marcas = this.marcasServicios.EditMarcas(estadoMaestra);
            return this.Ok(marcas);
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
            this.marcasServicios.DeleteMarcas(id);
        }
    }
}