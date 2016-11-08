// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenciasController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the ReferenciasController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Controllers.Administracion
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Feroza.VirtualPartes.Web.UI.Models;

    using Infraestructura.Data.Repositorios;
    using Infraestructura.Data.RepositoriosEf;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;

    /// <summary>The estado maestras controller.</summary>
    public class ReferenciasController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IReferenciasServicio referenciasServicios;

        /// <summary>The marcas servicios.</summary>
        private readonly IMarcasServicio marcasServicios;

        /// <summary>The sistemas servicios.</summary>
        private readonly ISistemasServicio sistemasServicios;

        /// <summary>The sub sistemas servicios.</summary>
        private readonly ISubSistemasServicio subSistemasServicios;

        public ReferenciasController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.referenciasServicios = new ReferenciasServicios(new Repository<Referencias>(new IocDbContext()), null);
            this.marcasServicios = new MarcasServicios(new Repository<Marcas>(new IocDbContext()), null);
            this.sistemasServicios = new SistemasServicios(new Repository<Sistemas>(new IocDbContext()), null);
            this.subSistemasServicios = new SubSistemasServicios(new Repository<SubSistemas>(new IocDbContext()), null);
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

        /// <summary>The estado maestras edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ReferenciasEditView()
        {
            return this.View("../Administracion/Referencias/ReferenciasEditView");
        }

        /// <summary>The estado maestras component.</summary>
        /// <returns>The <see cref="ActionResult"/> ReferenciasComponent.</returns>
        public ActionResult ReferenciasComponent()
        {
            return this.View("../Administracion/Referencias/ReferenciasComponent");
        }

        /// <summary>The get estado maestras model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetReferenciasModel(string id)
        {
            var success = false;
            var error = string.Empty;
            var response = new ReferenciasViewModel();
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var referenciasResultado = this.referenciasServicios.Get(id);
                    Mapper.CreateMap<Referencias, ReferenciasViewModel>();
                    response = Mapper.Map<ReferenciasViewModel>(referenciasResultado);
                }

                response.MarcasList = this.marcasServicios.List();
                response.SistemasList = this.sistemasServicios.List();
                response.SubSistemasList = this.subSistemasServicios.List();

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