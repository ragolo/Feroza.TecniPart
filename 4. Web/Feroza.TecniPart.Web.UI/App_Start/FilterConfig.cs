// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   The filter config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI
{
    using System.Web.Mvc;

    /// <summary>The filter config.</summary>
    public class FilterConfig
    {
        /// <summary>The register global filters.</summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}