﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FabricantesController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the FabricantesController type.
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
    public class FabricantesController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IFabricantesServicio fabricantesServicios;

        public FabricantesController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.fabricantesServicios = new FabricantesServicios(new EfFabricantesRepositorio());
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
            var response = new Fabricantes();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    response = this.fabricantesServicios.ListFabricantes(id.Value).FirstOrDefault();
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