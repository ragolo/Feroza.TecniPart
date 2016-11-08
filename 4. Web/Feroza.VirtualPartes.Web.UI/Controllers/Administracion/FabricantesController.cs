// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FabricantesController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the FabricantesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Controllers.Administracion
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Infraestructura.UnidadesDeTrabajo.EntityFramework;

    using Models;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;

    /// <summary>The estado maestras controller.</summary>
    public class FabricantesController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IFabricantesServicio fabricantesServicios;

        /// <summary>The pais servicios.</summary>
        private readonly IPaisesServicio paisServicios;

        /// <summary>Initializes a new instance of the <see cref="FabricantesController"/> class.</summary>
        public FabricantesController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.fabricantesServicios = new FabricantesServicios(new UnidadDeTrabajoAdministracion(), null);
            this.paisServicios = new PaisesServicios(new UnidadDeTrabajoAdministracion(), null);
        }

        // GET: Fabricantes

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Fabricantes/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult FabricantesListComponent()
        {
            return this.View("../Administracion/Fabricantes/FabricantesListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult FabricantesAddView()
        {
            return this.View("../Administracion/Fabricantes/FabricantesAddView");
        }

        /// <summary>The fabricantes edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult FabricantesEditView()
        {
            return this.View("../Administracion/Fabricantes/FabricantesEditView");
        }

        /// <summary>The fabricantes component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult FabricantesComponent()
        {
            return this.View("../Administracion/Fabricantes/FabricantesComponent");
        }

        /// <summary>The get fabricantes model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetFabricantesModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new FabricantesViewModel();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    var resultado = this.fabricantesServicios.Get(id.Value);
                    Mapper.CreateMap<Fabricantes, FabricantesViewModel>();
                    response = Mapper.Map<FabricantesViewModel>(resultado);
                }

                response.PaisList = this.paisServicios.ListFiltered(paises => paises.Activo);
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