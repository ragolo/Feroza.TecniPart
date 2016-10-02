// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Core.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Core type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Extensions
{
    using System;

    /// <summary>The core.</summary>
    public static class BusinessExtensions
    {
        /// <summary>The get image base 64 from byte.</summary>
        /// <param name="imageBytes">The image bytes.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetImageBase64FromByte(this byte[] imageBytes)
        {
            if (imageBytes != null)
            {
                return Convert.ToBase64String(imageBytes);
            }

            return string.Empty;
        }
    }
}
