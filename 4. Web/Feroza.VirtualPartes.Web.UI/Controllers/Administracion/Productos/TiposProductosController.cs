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
    public class TiposProductosController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly ITiposProductosServicio tiposProductosServicios;

        /// <summary>The lineas productos servicios.</summary>
        private readonly ILineasProductosServicio lineasProductosServicios;

        /// <summary>Initializes a new instance of the <see cref="TiposProductosController"/> class.</summary>
        public TiposProductosController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.tiposProductosServicios = new TiposProductosServicios(new UnidadDeTrabajoProductos(), null);
            this.lineasProductosServicios = new LineasProductosServicios(new UnidadDeTrabajoProductos(), null);
        }

        // GET: TiposProductos

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Productos/TiposProductos/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult TiposProductosListComponent()
        {
            return this.View("../Administracion/Productos/TiposProductos/TiposProductosListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult TiposProductosAddView()
        {
            return this.View("../Administracion/Productos/TiposProductos/TiposProductosAddView");
        }

        /// <summary>The tiposProductos edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult TiposProductosEditView()
        {
            return this.View("../Administracion/Productos/TiposProductos/TiposProductosEditView");
        }

        /// <summary>The tiposProductos component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult TiposProductosComponent()
        {
            return this.View("../Administracion/Productos/TiposProductos/TiposProductosComponent");
        }

        /// <summary>The get tiposProductos model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetTiposProductosModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new TiposProductosViewModel();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    var resultado = this.tiposProductosServicios.Get(id.Value);
                    Mapper.CreateMap<TiposProductos, TiposProductosViewModel>();
                    response = Mapper.Map<TiposProductosViewModel>(resultado);
                }

                response.LineasProductosList = this.lineasProductosServicios.List();
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