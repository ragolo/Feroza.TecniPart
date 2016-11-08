// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagementImageFacade.cs" company="Ragolo">
//   
// </copyright>
// <summary>
//   Defines the ManagementImageFacade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Facade
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;

    using Models;

    /// <summary>The management image facade.</summary>
    /// <typeparam name="Entity"></typeparam>
    public class ManagementImageFacade<Entity> : IManagementImageFacade<Entity>
    {
        /// <summary>The get entity with image.</summary>
        /// <param name="serverMapPath">The server map path.</param>
        /// <param name="httpContent">The http content.</param>
        /// <returns>The <see cref="Entity"/>.</returns>
        public async Task<EntityWithImageModel<Entity>> GetEntityWithImage(string serverMapPath, HttpContent httpContent)
        {
            try
            {
                return await this.GetEntityWithImageModel(serverMapPath, httpContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The get entity with image model.</summary>
        /// <param name="serverMapPath">The server map path.</param>
        /// <param name="httpContent">The http content.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        /// <exception cref="HttpResponseException"></exception>
        private async Task<EntityWithImageModel<Entity>> GetEntityWithImageModel(string serverMapPath, HttpContent httpContent)
        {
            if (!httpContent.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var root = HttpContext.Current.Server.MapPath(serverMapPath);

            Directory.CreateDirectory(root);

            var provider = new MultipartFormDataStreamProvider(root);

            var taskEntityWithImageModel = await httpContent.ReadAsMultipartAsync(provider).ContinueWith<IEnumerable<EntityWithImageModel<Entity>>>(
                t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }

                        var entityWithImageModel = new EntityWithImageModel<Entity>();
                        FileInfo info;
                        var fileData = provider.FileData.Select(
                            i =>
                                {
                                    info = new FileInfo(i.LocalFileName);
                                    var imageByte = File.ReadAllBytes(info.FullName);
                                    entityWithImageModel.EntityModel = this.MappingEntityWithImageModel(provider.FormData);
                                    entityWithImageModel.FileDescription = new FileDescription(info.Name, info.FullName, info.Length / 1024, imageByte);
                                    return entityWithImageModel;
                                });

                        return fileData;
                    });

            return taskEntityWithImageModel.FirstOrDefault();
        }

        /// <summary>The mapping entity with image model.</summary>
        /// <param name="formData">The form data.</param>
        /// <returns>The <see cref="Entity"/>.</returns>
        private Entity MappingEntityWithImageModel(NameValueCollection formData)
        {
            var model = formData["model"];
            return Ragolo.Core.Serializers.JsonSerializer.Deserialize<Entity>(model);
        }
    }
}