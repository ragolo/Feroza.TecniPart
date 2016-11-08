namespace Feroza.VirtualPartes.Web.UI.Controllers.Administracion.Productos
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using Dominio.Entidades.Modelos.Productos;
    using Dominio.Interfaces.Administracion.Productos;

    using Feroza.VirtualPartes.Dominio.Entidades.Modelos;
    using Feroza.VirtualPartes.Infraestructura.UnidadesDeTrabajo.EntityFramework;
    using Feroza.VirtualPartes.Web.UI.Models;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion.Producto;

    /// <summary>The lineas productos controller.</summary>
    public class LineasProductosController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly ILineasProductosServicio lineasProductosServicios;

        /// <summary>Initializes a new instance of the <see cref="LineasProductosController"/> class.</summary>
        public LineasProductosController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.lineasProductosServicios = new LineasProductosServicios(new UnidadDeTrabajoProductos(), null);
        }

        // GET: LineasProductos

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Productos/LineasProductos/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult LineasProductosListComponent()
        {
            return this.View("../Administracion/Productos/LineasProductos/LineasProductosListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult LineasProductosAddView()
        {
            return this.View("../Administracion/Productos/LineasProductos/LineasProductosAddView");
        }

        /// <summary>The lineasProductos edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult LineasProductosEditView()
        {
            return this.View("../Administracion/Productos/LineasProductos/LineasProductosEditView");
        }

        /// <summary>The lineasProductos component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult LineasProductosComponent()
        {
            return this.View("../Administracion/Productos/LineasProductos/LineasProductosComponent");
        }

        /// <summary>The get lineasProductos model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetLineasProductosModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new LineasProductos();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    response = this.lineasProductosServicios.Get(id.Value);
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