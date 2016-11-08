// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidateModelStateFilter.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the ValidateModelStateFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Filters
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    /// <summary>The validate model state filter.</summary>
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        /// <summary>The on action executing.</summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}