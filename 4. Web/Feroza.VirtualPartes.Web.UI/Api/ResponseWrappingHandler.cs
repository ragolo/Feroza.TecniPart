// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseWrappingHandler.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ResponseWrappingHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Newtonsoft.Json;

    /// <summary>The response wrapping handler.</summary>
    public class ResponseWrappingHandler : DelegatingHandler
    {

        //TODO: Modificar ResponsePackage para que la API nos envie el codigo error y mensaje para el tema de multi lenguage, con el codigo de error capturamos el la etiqueta en el front-end

        /// <summary>The send async.</summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Step 1: Wait for the Response
            var response = await base.SendAsync(request, cancellationToken);

            return BuildApiResponse(request, response);
        }

        /// <summary>The build api response.</summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        private HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            object content;
            List<string> modelStateErrors = new List<string>();
            var success = true;

            //Obtiene el Response Content
            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                HttpError error = content as HttpError;
                if (error != null)
                {
                    content = null;
                    success = false;
                    var httpErrorObject = response.Content.ReadAsStringAsync().Result;
                    if (error.ModelState != null)
                    {
                        //Convertimos el objeto a anonimo
                        var anonymousErrorObject = new { message = "", ModelState = new Dictionary<string, string[]>() };

                        // Descerializamos objeto anonimo
                        var deserializedErrorObject = JsonConvert.DeserializeAnonymousType(
                            httpErrorObject,
                            anonymousErrorObject);

                        // Obtenemos los mensajes de error desde el objeto ModelState
                        var modelStateValues = deserializedErrorObject.ModelState.Select(kvp => string.Join(". ", kvp.Value));

                        for (int i = 0; i < modelStateValues.Count(); i++)
                        {
                            modelStateErrors.Add(modelStateValues.ElementAt(i));
                        }
                    }
                    else if (!response.IsSuccessStatusCode)
                    {
                        var anonymousErrorObject = new { Message = string.Empty, ExceptionMessage = string.Empty };
                        var deserializedErrorObject = JsonConvert.DeserializeAnonymousType(httpErrorObject, anonymousErrorObject);
                        modelStateErrors.Add(deserializedErrorObject.ExceptionMessage);
                    }
                }
            }

            var newResponse = request.CreateResponse(response.StatusCode, new ResponsePackage(content, modelStateErrors, success));

            //Agrega de vuelta la respuesta del encabezado
            foreach (var header in response.Headers)
            {
                newResponse.Headers.Add(header.Key, header.Value);
            }

            return newResponse;
        }
    }
}