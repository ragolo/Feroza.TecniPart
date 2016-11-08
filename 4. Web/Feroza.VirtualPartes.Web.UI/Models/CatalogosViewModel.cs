// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogosViewModel.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the CatalogosViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Models
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;

    /// <summary>The fabricantes view model.</summary>
    public class CatalogosViewModel : Catalogos
    {
        /// <summary>Initializes a new instance of the <see cref="CatalogosViewModel"/> class.</summary>
        public CatalogosViewModel()
        {
            this.VehiculosList = new List<Vehiculos>();
            this.SistemasList = new List<Sistemas>();
            this.SubSistemasList = new List<SubSistemas>();
        }

        /// <summary>Gets or sets the pais list.</summary>
        public IEnumerable<Vehiculos> VehiculosList { get; set; }

        /// <summary>Gets or sets the sistemas list.</summary>
        public IEnumerable<Sistemas> SistemasList { get; set; }

        /// <summary>Gets or sets the sub sistemas list.</summary>
        public IEnumerable<SubSistemas> SubSistemasList { get; set; }

        /// <summary>Gets or sets the imagen fabricante base 64.</summary>
        public string ImagenCatalogoBase64 { get; set; }
    }
}