// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenciasController.cs" company="">
//   
// </copyright>
// <summary>
//   The lineas productos controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Controllers.Administracion.Referencias
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Dominio.Entidades.Modelos.Referencias;
    using Dominio.Interfaces.Administracion;
    using Dominio.Interfaces.Administracion.Referencias;

    using Feroza.VirtualPartes.Dominio.Interfaces.Administracion.Productos;

    using Infraestructura.UnidadesDeTrabajo.EntityFramework;

    using Models.Administracion.Referencias;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;
    using Servicios.Interfaces.Administracion.Producto;

    /// <summary>The lineas productos controller.</summary>
    public class ReferenciasController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IReferenciasServicio productosServicios;

        /// <summary>The marcas servicios.</summary>
        private readonly IMarcasServicio marcasServicios;

        private readonly IMarcasTiposProductosServicio marcasTiposProductosServicio;

        /// <summary>Initializes a new instance of the <see cref="ReferenciasController"/> class.</summary>
        public ReferenciasController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.productosServicios = new ReferenciasServicios(new UnidadDeTrabajoReferencias(), null);
            this.marcasServicios = new MarcasServicios(new UnidadDeTrabajoAdministracion(), null);
            this.marcasTiposProductosServicio = new MarcasTiposProductosServicios(new UnidadDeTrabajoProductos(), null);
        }

        // GET: Referencias

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Referencias/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ReferenciasListComponent()
        {
            return this.View("../Administracion/Referencias/ReferenciasListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult ReferenciasAddView()
        {
            return this.View("../Administracion/Referencias/ReferenciasAddView");
        }

        /// <summary>The productos edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ReferenciasEditView()
        {
            return this.View("../Administracion/Referencias/ReferenciasEditView");
        }

        /// <summary>The productos component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ReferenciasComponent()
        {
            return this.View("../Administracion/Referencias/ReferenciasComponent");
        }

        /// <summary>The get productos model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetReferenciasModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new ReferenciasViewModel();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    var resultado = this.productosServicios.Get(id.Value);
                    Mapper.CreateMap<Referencias, ReferenciasViewModel>();
                    response = Mapper.Map<ReferenciasViewModel>(resultado);
                }

                response.MarcasTiposProductosRelacionados = this.marcasTiposProductosServicio.List().Select(r => new ListaMarcasRelacionMarcasTiposProductosViewModel
                                                                                               {
                                                                                                   IdMarcasTiposProductos = r.IdMarcasTiposProductos,
                                                                                                   NombreMarcas = r.Marcas.Nombre
                                                                                               }).ToList();
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