// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SistemasController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the SistemasController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Controllers.Administracion
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Feroza.TecniPart.Infraestructura.Data.Repositorios;
    using Feroza.TecniPart.Infraestructura.Data.RepositoriosEf;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;

    /// <summary>The estado maestras controller.</summary>
    public class SistemasController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly ISistemasServicio sistemasServicios;

        public SistemasController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.sistemasServicios = new SistemasServicios(new Repository<Sistemas>(new IocDbContext()), null);
        }

        // GET: Sistemas

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Sistemas/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult SistemasListComponent()
        {
            return this.View("../Administracion/Sistemas/SistemasListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult SistemasAddView()
        {
            return this.View("../Administracion/Sistemas/SistemasAddView");
        }

        /// <summary>The estado maestras edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult SistemasEditView()
        {
            return this.View("../Administracion/Sistemas/SistemasEditView");
        }

        /// <summary>The estado maestras component.</summary>
        /// <returns>The <see cref="ActionResult"/> SistemasComponent.</returns>
        public ActionResult SistemasComponent()
        {
            return this.View("../Administracion/Sistemas/SistemasComponent");
        }

        /// <summary>The get estado maestras model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetSistemasModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new Sistemas();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    response = this.sistemasServicios.Get(id.Value);
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