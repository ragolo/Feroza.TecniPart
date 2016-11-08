// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Core.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Core type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos;

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

        /// <summary>The obtener relacion sistema padre sitemas hijos.</summary>
        /// <param name="items">The items.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public static List<Sistemas> ObtenerRelacionSistemaPadreSitemasHijos(this List<Sistemas> items)
        {
            items.ForEach(i => i.SistemasHijos = items.Where(ch => ch.IdSistemasPadre == i.IdSistemas).ToList());
            return items.Where(r => r.IdSistemasPadre == null).ToList();
        }
    }
}
