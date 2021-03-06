﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AppController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Controllers
{
    using System.Web.Mvc;

    /// <summary>The app controller.</summary>
    public class AppController : Controller
    {
        // GET: Home

        /// <summary>The index.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            return this.View();
        }
    }
}