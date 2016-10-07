// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogosController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the CatalogosController type.
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

    using Models;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;

    /// <summary>The estado maestras controller.</summary>
    public class CatalogosController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly ICatalogosServicio catalogosServicios;

        /// <summary>The vehiculos servicios.</summary>
        private readonly IVehiculosServicio vehiculosServicios;

        /// <summary>The sistemas servicios.</summary>
        private readonly ISistemasServicio sistemasServicios;

        /// <summary>The sub sistemas servicios.</summary>
        private readonly ISubSistemasServicio subSistemasServicios;

        /// <summary>Initializes a new instance of the <see cref="CatalogosController"/> class.</summary>
        public CatalogosController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.catalogosServicios = new CatalogosServicios(new EfCatalogosRepositorio());
            this.vehiculosServicios = new VehiculosServicios(new EfVehiculosRepositorio());
            this.sistemasServicios = new SistemasServicios(new EfSistemasRepositorio());
            this.subSistemasServicios = new SubSistemasServicios(new EfSubSistemasRepositorio());
            
        }

        // GET: Catalogos

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Catalogos/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult CatalogosListComponent()
        {
            return this.View("../Administracion/Catalogos/CatalogosListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult CatalogosAddView()
        {
            return this.View("../Administracion/Catalogos/CatalogosAddView");
        }

        /// <summary>The catalogos edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult CatalogosEditView()
        {
            return this.View("../Administracion/Catalogos/CatalogosEditView");
        }

        /// <summary>The catalogos component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult CatalogosComponent()
        {
            return this.View("../Administracion/Catalogos/CatalogosComponent");
        }

        /// <summary>The get catalogos model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetCatalogosModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new CatalogosViewModel();
            try
            {
                var catalogos = new Catalogos();

                if (id.HasValue && id.Value > 0)
                {
                    catalogos = this.catalogosServicios.ListCatalogos(id.Value).FirstOrDefault();
                }

                if (catalogos != null)
                {
                    response.IdCatalogos = catalogos.IdCatalogos;
                    response.IdVehiculos = catalogos.IdVehiculos;
                    response.IdSistemas = catalogos.IdSistemas;
                    response.IdSubSistemas = catalogos.IdSubSistemas;
                    response.ImagenCatalogo = catalogos.ImagenCatalogo;
                    if (catalogos.ImagenCatalogo != null)
                    {
                        response.ImagenCatalogoBase64 = Convert.ToBase64String(catalogos.ImagenCatalogo);
                    }
                }

                response.VehiculosList = this.vehiculosServicios.ListVehiculos();
                response.SistemasList = this.sistemasServicios.ListSistemas();
                response.SubSistemasList = this.subSistemasServicios.ListSubSistemas();
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