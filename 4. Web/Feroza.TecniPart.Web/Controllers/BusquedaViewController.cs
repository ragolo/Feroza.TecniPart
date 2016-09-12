// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusquedaViewController.cs" company="Feroza">
//   Derechos de autor feroza
// </copyright>
// <summary>
//   The busqueda view controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>The busqueda view controller.</summary>
    public class BusquedaViewController : Controller
    {
        /// <summary>The index.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>The menu view.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult MenuView()
        {
            return this.View();
        }
    }
}