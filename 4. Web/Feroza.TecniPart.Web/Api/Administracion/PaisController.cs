// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaisController.cs" company="Feroza">
//   The Feroza 2016
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.Api.Administracion
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

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
        public IEnumerable<Pais> Get(int idPais)
        {
            return this.paisServicios.ListPais(idPais);
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

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="descripcion">
        /// The descripcion.
        /// </param>
        [HttpPost]
        public void Post(string descripcion)
        {
            this.paisServicios.AddPais(new Pais { Descripcion = descripcion });
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