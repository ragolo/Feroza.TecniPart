// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EstadoMaestrasController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the EstadoMaestrasController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Controllers.Administracion
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Infraestructura.Data.Repositorios.Administracion;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;

    /// <summary>The estado maestras controller.</summary>
    public class EstadoMaestrasController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IEstadoMaestrasServicio estadoMaestrasServicios;

        public EstadoMaestrasController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.estadoMaestrasServicios = new EstadoMaestrasServicios(new EfEstadoMaestrasRepositorio());
        }

        // GET: EstadoMaestras

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/EstadoMaestras/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult EstadoMaestrasListComponent()
        {
            return this.View("../Administracion/EstadoMaestras/EstadoMaestrasListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult EstadoMaestrasAddView()
        {
            return this.View("../Administracion/EstadoMaestras/EstadoMaestrasAddView");
        }

        /// <summary>The estado maestras edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult EstadoMaestrasEditView()
        {
            return this.View("../Administracion/EstadoMaestras/EstadoMaestrasEditView");
        }

        /// <summary>The estado maestras component.</summary>
        /// <returns>The <see cref="ActionResult"/> EstadoMaestrasComponent.</returns>
        public ActionResult EstadoMaestrasComponent()
        {
            return this.View("../Administracion/EstadoMaestras/EstadoMaestrasComponent");
        }

        /// <summary>The get estado maestras model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        [HttpPost]
        public ContentResult GetEstadoMaestrasModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new EstadoMaestras();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    response = this.estadoMaestrasServicios.ListEstadoMaestras(id.Value).FirstOrDefault();
                }

                success = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            var json = JsonConvert.SerializeObject(
                new
                {
                    success,
                    error,
                    result = response
                },
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return this.Content(json, "application/json");
        }
    }
}