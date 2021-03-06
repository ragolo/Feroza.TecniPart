﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the MarcasController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Controllers.Administracion
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Feroza.VirtualPartes.Infraestructura.UnidadesDeTrabajo.EntityFramework;
    using Feroza.VirtualPartes.Web.UI.Models;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;

    /// <summary>The estado maestras controller.</summary>
    public class MarcasController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IMarcasServicio marcasServicios;

        /// <summary>The fabricantes servicios.</summary>
        private readonly IFabricantesServicio fabricantesServicios;

        public MarcasController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            this.marcasServicios = new MarcasServicios(new UnidadDeTrabajoAdministracion(), null);
            this.fabricantesServicios = new FabricantesServicios(new UnidadDeTrabajoAdministracion(), null);
        }

        // GET: Marcas

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Marcas/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult MarcasListComponent()
        {
            return this.View("../Administracion/Marcas/MarcasListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult MarcasAddView()
        {
            return this.View("../Administracion/Marcas/MarcasAddView");
        }

        /// <summary>The estado maestras edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult MarcasEditView()
        {
            return this.View("../Administracion/Marcas/MarcasEditView");
        }

        /// <summary>The estado maestras component.</summary>
        /// <returns>The <see cref="ActionResult"/> MarcasComponent.</returns>
        public ActionResult MarcasComponent()
        {
            return this.View("../Administracion/Marcas/MarcasComponent");
        }

        /// <summary>The get estado maestras model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetMarcasModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new MarcasViewModel();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    var resultado = this.marcasServicios.Get(id.Value);
                    Mapper.CreateMap<Marcas, MarcasViewModel>();
                    response = Mapper.Map<MarcasViewModel>(resultado);
                }

                response.FabricantesList = this.fabricantesServicios.List();
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