// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponsePackage.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   The response package.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Api
{
    using System.Collections.Generic;

    /// <summary>The response package.</summary>
    public class ResponsePackage
    {
        /// <summary>Gets or sets the errors.</summary>
        public List<string> errors { get; set; }

        /// <summary>Gets or sets the result.</summary>
        public object result { get; set; }

        /// <summary>Gets or sets a value indicating whether success.</summary>
        public bool success { get; set; }

        /// <summary>Initializes a new instance of the <see cref="ResponsePackage"/> class.</summary>
        /// <param name="result">The result.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="success">The success.</param>
        public ResponsePackage(object result, List<string> errors, bool success)
        {
            this.errors = errors;
            this.result = result;
            this.success = success;
        }
    }
}