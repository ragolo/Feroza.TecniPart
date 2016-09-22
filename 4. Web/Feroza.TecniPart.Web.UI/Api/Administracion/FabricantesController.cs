// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FabricantesController.cs" company="Feroza">
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
    public class FabricantesController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IFabricantesServicio fabricantesServicios;

        /// <summary>
        /// Initializes a new instance of the <see cref="FabricantesController"/> class.
        /// </summary>
        /// <param name="fabricantesServicios">
        /// The estado maestras servicios.
        /// </param>
        public FabricantesController(IFabricantesServicio fabricantesServicios)
        {
            this.fabricantesServicios = fabricantesServicios;
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
        public Fabricantes Get(int id)
        {
            return this.fabricantesServicios.ListFabricantes(id).FirstOrDefault();
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<Fabricantes> Get()
        {
            return this.fabricantesServicios.ListFabricantes();
        }

        /// <summary>The post estado maestras.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult PostFabricantes(Fabricantes fabricantes)
        {
            var fabricantesResult = this.fabricantesServicios.AddFabricantes(fabricantes);
            return this.Ok(fabricantesResult);
        }

        /// <summary>The put fabricantes.</summary>
        /// <param name="estadoMaestra">The estado maestra.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult PutFabricantes(Fabricantes estadoMaestra)
        {
            var fabricantes = this.fabricantesServicios.EditFabricantes(estadoMaestra);
            return this.Ok(fabricantes);
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
            this.fabricantesServicios.DeleteFabricantes(id);
        }
    }
}