// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaisController.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the PaisController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.Controllers.Administracion
{
    using System.Web.Mvc;

    /// <summary>The estado maestras controller.</summary>
    public class PaisController : Controller
    {
        // GET: Pais

        /// <summary>The index.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            return this.View("../Administracion/Pais/index");
        }

        /// <summary>The listar.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Listar()
        {
            return this.View("../Administracion/Pais/Listar");
        }
    }
}