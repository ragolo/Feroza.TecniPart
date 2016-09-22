// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductosController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the ProductosController type.
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
    public class ProductosController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IProductosServicio productossServicios;

        public ProductosController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.productossServicios = new ProductosServicios(new EfProductosRepositorio());
        }

        // GET: Productos

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Productos/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ProductosListComponent()
        {
            return this.View("../Administracion/Productos/ProductosListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult ProductosAddView()
        {
            return this.View("../Administracion/Productos/ProductosAddView");
        }

        /// <summary>The estado maestras edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ProductosEditView()
        {
            return this.View("../Administracion/Productos/ProductosEditView");
        }

        /// <summary>The estado maestras component.</summary>
        /// <returns>The <see cref="ActionResult"/> ProductosComponent.</returns>
        public ActionResult ProductosComponent()
        {
            return this.View("../Administracion/Productos/ProductosComponent");
        }

        /// <summary>The get estado maestras model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetProductosModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new Productos();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    response = this.productossServicios.ListProductos(id.Value).FirstOrDefault();
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