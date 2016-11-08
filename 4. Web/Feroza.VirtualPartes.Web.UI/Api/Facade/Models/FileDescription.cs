// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileDescription.cs" company="Newshore">
//   Newshore
// </copyright>
// <summary>
//   The file description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Models
{
    public class FileDescription
    {

        /// <summary>Initializes a new instance of the <see cref="FileDescription"/> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="path">The path.</param>
        /// <param name="size">The size.</param>
        /// <param name="imageBytes"></param>
        public FileDescription(string name, string path, long size, byte[] imageBytes)
        {
            this.Name = name;
            this.Path = path;
            this.Size = size;
            this.ImageBytes = imageBytes;
        }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the path.</summary>
        public string Path { get; set; }

        /// <summary>Gets or sets the size.</summary>
        public long Size { get; set; }

        /// <summary>Gets or sets the image bytes.</summary>
        public byte[] ImageBytes { get; set; }
    }
}