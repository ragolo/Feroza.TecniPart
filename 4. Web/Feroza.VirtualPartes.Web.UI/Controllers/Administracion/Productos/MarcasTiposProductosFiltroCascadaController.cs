namespace Feroza.VirtualPartes.Web.UI.Controllers.Administracion.Productos
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using Dominio.Entidades.Modelos.Productos;
    using Dominio.Interfaces.Administracion;
    using Dominio.Interfaces.Administracion.Productos;

    using Infraestructura.UnidadesDeTrabajo.EntityFramework;

    using Models;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;
    using Servicios.Interfaces.Administracion.Producto;

    /// <summary>The lineas productos controller.</summary>
    public class MarcasTiposProductosFiltroCascadaController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IMarcasTiposProductosServicio marcasTiposProductosServicios;

        private readonly ITiposProductosServicio tiposProductosServicios;

        private readonly IMarcasServicio marcasServicios;

        /// <summary>Initializes a new instance of the <see cref="MarcasTiposProductosController"/> class.</summary>
        public MarcasTiposProductosFiltroCascadaController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.marcasTiposProductosServicios = new MarcasTiposProductosServicios(new UnidadDeTrabajoProductos(), null);
            this.tiposProductosServicios = new TiposProductosServicios(new UnidadDeTrabajoProductos(), null);
            this.marcasServicios = new MarcasServicios(new UnidadDeTrabajoAdministracion(), null);
        }


        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult MarcasTiposProductosFiltroCascadaComponent()
        {
            return this.View("../Administracion/Productos/MarcasTiposProductos/MarcasTiposProductosFiltroCascadaComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult MarcasTiposProductosFiltroCascadaView()
        {
            return this.View("../Administracion/Productos/MarcasTiposProductos/MarcasTiposProductosFiltroCascadaView");
        }

        /// <summary>The get marcasTiposProductos model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetMarcasTiposProductosFiltroCascadaModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new MarcasTiposProductosViewModel();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    var resultado = this.marcasTiposProductosServicios.ObtenerListaTiposProductosPorMarcasTipos();
                    Mapper.CreateMap<MarcasTiposProductos, MarcasTiposProductosViewModel>();
                    response = Mapper.Map<MarcasTiposProductosViewModel>(resultado);
                }

                response.TiposProductosList = this.tiposProductosServicios.List();
                response.MarcasList = this.marcasServicios.List();
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