// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FabricantesViewModel.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the FabricantesViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Models
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;

    /// <summary>The fabricantes view model.</summary>
    public class FabricantesViewModel : Fabricantes
    {
        /// <summary>Initializes a new instance of the <see cref="FabricantesViewModel"/> class.</summary>
        public FabricantesViewModel()
        {
            this.PaisList = new List<Pais>();
        }

        /// <summary>Gets or sets the pais list.</summary>
        public IEnumerable<Pais> PaisList { get; set; }

        /// <summary>Gets or sets the imagen fabricante base 64.</summary>
        public string ImagenFabricanteBase64 { get; set; }
    }
}