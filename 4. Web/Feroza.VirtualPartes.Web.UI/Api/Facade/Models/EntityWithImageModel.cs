// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityWithImageModel.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the EntityWithImageModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Models
{
    /// <summary>The entity with image model.</summary>
    /// <typeparam name="Entity"></typeparam>
    public class EntityWithImageModel<Entity>
    {
        /// <summary>Gets or sets the entity model.</summary>
        public Entity EntityModel { get; set; }

        /// <summary>Gets or sets the image bytes.</summary>
        public FileDescription FileDescription { get; set; }
    }
}