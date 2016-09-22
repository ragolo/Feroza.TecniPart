﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EstadoMaestrasController.cs" company="Feroza">
//   The Feroza 2016
// </copyright>
// <summary>
//   The estado maestras controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Api.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        private readonly IEstadoMaestrasServicio estadoMaestrasServicios;

        /// <summary>
        /// Initializes a new instance of the <see cref="EstadoMaestrasController"/> class.
        /// </summary>
        /// <param name="estadoMaestrasServicios">
        /// The estado maestras servicios.
        /// </param>
        public EstadoMaestrasController(IEstadoMaestrasServicio estadoMaestrasServicios)
        {
            this.estadoMaestrasServicios = estadoMaestrasServicios;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public EstadoMaestras Get(int id)
        {
            return this.estadoMaestrasServicios.ListEstadoMaestras(id).FirstOrDefault();
        }

        /// <summary>The get.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        [HttpGet]
        public IEnumerable<EstadoMaestras> Get()
        {
            return this.estadoMaestrasServicios.ListEstadoMaestras();
        }

        /// <summary>The post estado maestras.</summary>
        /// <param name="estadoMaestra">The estado maestra.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        public IHttpActionResult Post(EstadoMaestras estadoMaestra)
        {
            var estadoMaestras = this.estadoMaestrasServicios.AddEstadoMaestras(estadoMaestra);
            return this.Ok(estadoMaestras);
        }

        /// <summary>The put estado maestras.</summary>
        /// <param name="estadoMaestra">The estado maestra.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPut]
        public IHttpActionResult Put(EstadoMaestras estadoMaestra)
        {
            var estadoMaestras = this.estadoMaestrasServicios.EditEstadoMaestras(estadoMaestra);
            return this.Ok(estadoMaestras);
        }

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.estadoMaestrasServicios.DeleteEstadoMaestras(id);
                return this.Ok(id);
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }
    }
}