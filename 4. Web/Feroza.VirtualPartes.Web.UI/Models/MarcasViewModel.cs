// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The marcas view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Models
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;

    /// <summary>The marcas view model.</summary>
    public class MarcasViewModel : Marcas
    {
        /// <summary>Initializes a new instance of the <see cref="MarcasViewModel"/> class.</summary>
        public MarcasViewModel()
        {
            this.FabricantesList = new List<Fabricantes>();
        }

        /// <summary>Gets or sets the fabricantes list.</summary>
        public IEnumerable<Fabricantes> FabricantesList { get; set; }

        /// <summary>Gets or sets the imagen base 64.</summary>
        public string ImagenBase64 { get; set; }
    }
}