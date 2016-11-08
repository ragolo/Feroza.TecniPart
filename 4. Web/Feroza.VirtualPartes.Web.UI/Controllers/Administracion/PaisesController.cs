// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaisesController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the PaisesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Controllers.Administracion
{
    using System;
    using System.Web.Mvc;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;
    using Feroza.VirtualPartes.Infraestructura.UnidadesDeTrabajo.EntityFramework;

    using Newtonsoft.Json;

    using Servicios.Interfaces.Administracion;

    /// <summary>The estado maestras controller.</summary>
    public class PaisesController : Controller
    {
        /// <summary>The estado maestras servicios.</summary>
        private readonly IPaisesServicio paisServicios;

        public PaisesController()
        {
            //TODO: Se debe enviar por inyeccion de dependencia y resolver con Windsor, adicional no olvidar quitar la referencia de Feroza.TecniPart.Infraestructura sobre este proyecto
            //this.paisServicios = new PaisesServicios(new Repository<Paises>(new UnidadDeTrabajoAdministracionInicial()), null);
        }

        // GET: Paises

        /// <summary>The index view.</summary>
        /// <returns>The <see cref="ActionResult"/> IndexView.</returns>
        public ActionResult IndexView()
        {
            return this.View("../Administracion/Paises/IndexView");
        }

        /// <summary>The estado maestras list component.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult PaisesListComponent()
        {
            return this.View("../Administracion/Paises/PaisesListComponent");
        }

        /// <summary>The agregar view.</summary>
        /// <returns>The <see cref="ActionResult"/> AgregarView.</returns>
        public ActionResult PaisesAddView()
        {
            return this.View("../Administracion/Paises/PaisesAddView");
        }

        /// <summary>The estado maestras edit view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult PaisesEditView()
        {
            return this.View("../Administracion/Paises/PaisesEditView");
        }

        /// <summary>The estado maestras component.</summary>
        /// <returns>The <see cref="ActionResult"/> PaisesComponent.</returns>
        public ActionResult PaisesComponent()
        {
            return this.View("../Administracion/Paises/PaisesComponent");
        }

        /// <summary>The get estado maestras model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ContentResult"/>.</returns>
        public ContentResult GetPaisesModel(int? id)
        {
            var success = false;
            var error = string.Empty;
            var response = new Paises();
            try
            {
                if (id.HasValue)
                {
                    response = this.paisServicios.Get(id.Value);
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