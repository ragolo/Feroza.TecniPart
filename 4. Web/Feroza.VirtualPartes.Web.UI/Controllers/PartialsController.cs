// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartialsController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the PartialsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Controllers
{
    using System.Web.Mvc;

    /// <summary>The partials controller.</summary>
    public class PartialsController : Controller
    {
        /// <summary>The top navbar.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult TopNavbar()
        {
            return this.PartialView();
        }

        /// <summary>The sidebar.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Sidebar()
        {
            return this.PartialView();
        }

        /// <summary>The offsidebar.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Offsidebar()
        {
            return this.PartialView();
        }

        /// <summary>The footer.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Footer()
        {
            return this.PartialView();
        }

        /// <summary>The offsidebar tab 1.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult OffsidebarTab1()
        {
            return this.PartialView();
        }

        /// <summary>The offsidebar tab 2.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult OffsidebarTab2()
        {
            return this.PartialView();
        }

        /// <summary>The modal service.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ModalService()
        {
            return this.PartialView();
        }

        /// <summary>The modal imagenes.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult VisorImagen()
        {
            return this.PartialView();
        }
    }
}