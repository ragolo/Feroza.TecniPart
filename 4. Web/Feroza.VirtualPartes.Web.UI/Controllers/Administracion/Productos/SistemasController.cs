namespace Feroza.VirtualPartes.Web.UI.Controllers.Administracion.Productos
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos;
    using Feroza.VirtualPartes.Dominio.Interfaces.Administracion.Productos;
    using Feroza.VirtualPartes.Infraestructura.UnidadesDeTrabajo.EntityFramework;
    using Feroza.VirtualPartes.Servicios.Interfaces.Administracion.Producto;
    using Feroza.VirtualPartes.Web.UI.Models;

    using Newtonsoft.Json;

    /// <summary>The lineas sistemas controller.</summary>
    public class SistemasController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly ISistemasServicio sistemasServicios;

        /// <summary>Initializes a new instance of the <see cref="SistemasController"/> class.</summary>
        public SistemasController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.sistemasServicios = new SistemasServicios(new UnidadDeTrabajoProductos(), null);
        }

        // GET: Sistemas

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Productos/Sistemas/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult SistemasListComponent()
        {
            return this.View("../Administracion/Productos/Sistemas/SistemasListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult SistemasAddView()
        {
            return this.View("../Administracion/Productos/Sistemas/SistemasAddView");
        }

        /// <summary>The sistemas edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult SistemasEditView()
        {
            return this.View("../Administracion/Productos/Sistemas/SistemasEditView");
        }

        /// <summary>The sistemas component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult SistemasComponent()
        {
            return this.View("../Administracion/Productos/Sistemas/SistemasComponent");
        }

        /// <summary>The get sistemas model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetSistemasModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new SistemasViewModel();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    var resultado = this.sistemasServicios.Get(id.Value);
                    Mapper.CreateMap<Sistemas, SistemasViewModel>();
                    response = Mapper.Map<SistemasViewModel>(resultado);
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