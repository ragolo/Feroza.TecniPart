// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EstadoMaestrasController.cs" company="Feroza">
//   The Feroza 2016
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Api
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The estado maestras controller.
    /// </summary>
    public class EstadoMaestrasController : ApiController
    {
        /// <summary>
        /// The estado maestras servicios.
        /// </summary>
        private readonly IEstadoMaestrasServicios estadoMaestrasServicios;

        /// <summary>
        /// Initializes a new instance of the <see cref="EstadoMaestrasController"/> class.
        /// </summary>
        /// <param name="estadoMaestrasServicios">
        /// The estado maestras servicios.
        /// </param>
        public EstadoMaestrasController(IEstadoMaestrasServicios estadoMaestrasServicios)
        {
            this.estadoMaestrasServicios = estadoMaestrasServicios;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="idEstadoMaestras">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        [HttpGet]
        public IEnumerable<EstadoMaestras> Get(int idEstadoMaestras)
        {
            return this.estadoMaestrasServicios.ListEstadoMaestras(idEstadoMaestras);
        }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="descripcion">
        /// The descripcion.
        /// </param>
        public void Post(string descripcion)
        {
            this.estadoMaestrasServicios.AddEstadoMaestras(new EstadoMaestras { Desripcion = descripcion });
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            this.estadoMaestrasServicios.DeleteEstadoMaestras(id);
        }
    }
}
