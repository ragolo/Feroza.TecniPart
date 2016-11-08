// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculosController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the VehiculosController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Controllers.Administracion
{
    using System;
    using System.Web.Mvc;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Infraestructura.Data.Repositorios;
    using Infraestructura.Data.RepositoriosEf;

    using Models;

    using Newtonsoft.Json;

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

        /// <summary>Initializes a new instance of the <see cref="VehiculosController"/> class.</summary>
        public VehiculosController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.vehiculosServicios = new VehiculosServicios(new Repository<Vehiculos>(new IocDbContext()), null);
            this.fabricantesServicios = new FabricantesServicios(new Repository<Fabricantes>(new IocDbContext()), null);
            this.marcasServicios = new MarcasServicios(new Repository<Marcas>(new IocDbContext()), null);
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
                    vehiculos = this.vehiculosServicios.Get(id.Value);
                }

                if (vehiculos != null)
                {
                    response.IdVehiculos = vehiculos.IdVehiculos;
                    response.Descripcion = vehiculos.Descripcion;
                    response.IdFabricantes = vehiculos.IdFabricantes;
                    response.ImagenVehiculo = vehiculos.ImagenVehiculo;
                    response.IdMarca = vehiculos.IdMarca;
                    response.Ango = vehiculos.Ango;
                    response.Comentario = vehiculos.Comentario;

                    if (vehiculos.ImagenVehiculo != null)
                    {
                        response.ImagenVehiculoBase64 = Convert.ToBase64String(vehiculos.ImagenVehiculo);
                    }
                }

                response.FabricantesList = this.fabricantesServicios.List();
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