// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginController.cs" company="Newshore">
//   Newshore
// </copyright>
// <summary>
//   Defines the LoginController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Controllers.Acceso
{
    using System.Web.Mvc;

    /// <summary>The login controller.</summary>
    public class AccesoController : Controller
    {
        /// <summary>The index.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>The login.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Login()
        {
            return this.View();
        }
    }
}