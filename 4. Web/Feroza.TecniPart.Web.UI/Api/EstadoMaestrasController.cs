using Feroza.TecniPart.Dominio.Interfaces.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Feroza.TecniPart.Web.UI.Api
{
    using Feroza.TecniPart.Dominio.Entidades.Modelos;
    using Servicios.Interfaces.Administracion;

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
        /// The <see cref="IEnumerable"/>.
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
