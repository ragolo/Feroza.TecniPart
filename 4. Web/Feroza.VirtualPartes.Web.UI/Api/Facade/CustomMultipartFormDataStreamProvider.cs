// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomMultipartFormDataStreamProvider.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   The custom multipart form data stream provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api.Facade
{
    using System.Net.Http;

    /// <summary>The custom multipart form data stream provider.</summary>
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        /// <summary>Initializes a new instance of the <see cref="CustomMultipartFormDataStreamProvider"/> class.</summary>
        /// <param name="path">The path.</param>
        public CustomMultipartFormDataStreamProvider(string path) : base(path)
        {
        }

        /// <summary>The get local file name.</summary>
        /// <param name="headers">The headers.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";

            // this is here because Chrome submits files in quotation marks which get treated as part of the filename and get escaped
            return name.Replace("\"", string.Empty);
        }
    }
}