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
    public class ProductosController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IProductosServicio productosServicios;

        /// <summary>The lineas productos servicios.</summary>
        private readonly IMarcasTiposProductosServicio marcasTiposProductosServicios;

        /// <summary>Initializes a new instance of the <see cref="ProductosController"/> class.</summary>
        public ProductosController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.productosServicios = new ProductosServicios(new UnidadDeTrabajoProductos(), null);
            this.marcasTiposProductosServicios = new MarcasTiposProductosServicios(new UnidadDeTrabajoProductos(), null);
        }

        // GET: Productos

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Productos/Productos/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ProductosListComponent()
        {
            return this.View("../Administracion/Productos/Productos/ProductosListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult ProductosAddView()
        {
            return this.View("../Administracion/Productos/Productos/ProductosAddView");
        }

        /// <summary>The productos edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ProductosEditView()
        {
            return this.View("../Administracion/Productos/Productos/ProductosEditView");
        }

        /// <summary>The productos component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ProductosComponent()
        {
            return this.View("../Administracion/Productos/Productos/ProductosComponent");
        }

        /// <summary>The get productos model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetProductosModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new ProductosViewModel();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    var resultado = this.productosServicios.Get(id.Value);
                    Mapper.CreateMap<Productos, ProductosViewModel>();
                    response = Mapper.Map<ProductosViewModel>(resultado);
                }

                response.MarcasTiposProductosList = this.marcasTiposProductosServicios.List();
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