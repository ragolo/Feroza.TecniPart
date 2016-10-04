// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubSistemasController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the SubSistemasController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Controllers.Administracion
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Feroza.TecniPart.Web.UI.Models;

    using Infraestructura.Data.Repositorios.Administracion;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;

    /// <summary>The estado maestras controller.</summary>
    public class SubSistemasController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly ISubSistemasServicio subSistemasServicios;

        /// <summary>The sistemas servicio.</summary>
        private readonly ISistemasServicio sistemasServicio;

        /// <summary>Initializes a new instance of the <see cref="SubSistemasController"/> class.</summary>
        public SubSistemasController()
        {
            this.subSistemasServicios = new SubSistemasServicios(new EfSubSistemasRepositorio());
            this.sistemasServicio = new SistemasServicios(new EfSistemasRepositorio());
        }

        // GET: SubSistemas

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/SubSistemas/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult SubSistemasListComponent()
        {
            return this.View("../Administracion/SubSistemas/SubSistemasListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult SubSistemasAddView()
        {
            return this.View("../Administracion/SubSistemas/SubSistemasAddView");
        }

        /// <summary>The estado maestras edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult SubSistemasEditView()
        {
            return this.View("../Administracion/SubSistemas/SubSistemasEditView");
        }

        /// <summary>The estado maestras component.</summary>
        /// <returns>The <see cref="ActionResult"/> SubSistemasComponent.</returns>
        public ActionResult SubSistemasComponent()
        {
            return this.View("../Administracion/SubSistemas/SubSistemasComponent");
        }

        /// <summary>The get sub sistemas model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetSubSistemasModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new SubSistemasViewModel();
            try
            {
                var subSistemas = new SubSistemas();

                if (id.HasValue && id.Value > 0)
                {
                    subSistemas = this.subSistemasServicios.ListSubSistemas(id.Value).FirstOrDefault();
                }

                if (subSistemas != null)
                {
                    response.Descripcion = subSistemas.Descripcion;
                    response.IdSistemas = subSistemas.IdSistemas;
                    response.IdSubSistemas = subSistemas.IdSubSistemas;
                    response.Sistemas = subSistemas.Sistemas;
                }

                response.SistemasList = this.sistemasServicio.ListSistemas();
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