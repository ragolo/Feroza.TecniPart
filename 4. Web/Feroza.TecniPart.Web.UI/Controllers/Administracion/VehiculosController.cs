// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculosController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the VehiculosController type.
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

    using Ragolo.Core.Mapper;

    using Servicios.Interfaces.Administracion;

    /// <summary>The estado maestras controller.</summary>
    public class VehiculosController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IVehiculosServicio vehiculosServicios;

        /// <summary>The fabricantes servicios.</summary>
        private readonly IFabricantesServicio fabricantesServicios;

        /// <summary>The marcas servicios.</summary>
        private readonly IMarcasServicio marcasServicios;


        public VehiculosController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.vehiculosServicios = new VehiculosServicios(new EfVehiculosRepositorio());
            this.fabricantesServicios = new FabricantesServicios(new EfFabricantesRepositorio());
            this.marcasServicios = new MarcasServicios(new EfMarcasRepositorio());

        }

        // GET: Vehiculos

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Vehiculos/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult VehiculosListComponent()
        {
            return this.View("../Administracion/Vehiculos/VehiculosListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult VehiculosAddView()
        {
            return this.View("../Administracion/Vehiculos/VehiculosAddView");
        }

        /// <summary>The estado maestras edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult VehiculosEditView()
        {
            return this.View("../Administracion/Vehiculos/VehiculosEditView");
        }

        /// <summary>The estado maestras component.</summary>
        /// <returns>The <see cref="ActionResult"/> VehiculosComponent.</returns>
        public ActionResult VehiculosComponent()
        {
            return this.View("../Administracion/Vehiculos/VehiculosComponent");
        }

        /// <summary>The get estado maestras model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetVehiculosModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new VehiculosViewModel();
            try
            {
                var vehiculos = new Vehiculos();

                if (id.HasValue && id.Value > 0)
                {
                    vehiculos = this.vehiculosServicios.ListVehiculos(id.Value).FirstOrDefault();
                }

                response = BaseEntityMapperViewModel<VehiculosViewModel, Vehiculos>.MapFromEntity(vehiculos);

                response.FabricantesList = this.fabricantesServicios.ListFabricantes();
                response.MarcasList = this.marcasServicios.ListMarcas();

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