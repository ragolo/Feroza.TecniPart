// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IManagementImageFacade.cs" company="">
//   
// </copyright>
// <summary>
//   The ManagementImageFacade interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Facade
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using Models;

    /// <summary>The ManagementImageFacade interface.</summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IManagementImageFacade<Entity>
    {
        /// <summary>The get entity with image.</summary>
        /// <param name="appDataTempFileuploads">The app data temp fileuploads.</param>
        /// <param name="requestContent">The request content.</param>
        /// <returns>The <see cref="EntityWithImageModel"/>.</returns>
        Task<EntityWithImageModel<Entity>> GetEntityWithImage(string appDataTempFileuploads, HttpContent requestContent);
    }
}