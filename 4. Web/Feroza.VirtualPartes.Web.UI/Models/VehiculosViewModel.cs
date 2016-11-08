// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculosViewModel.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the VehiculosViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Models
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;

    /// <summary>The vehiculos view model.</summary>
    public class VehiculosViewModel : Vehiculos
    {
        /// <summary>Initializes a new instance of the <see cref="VehiculosViewModel"/> class.</summary>
        public VehiculosViewModel()
        {
            this.FabricantesList = new List<Fabricantes>();
            this.MarcasList = new List<Marcas>();
        }

        /// <summary>Gets or sets the pais list.</summary>
        public IEnumerable<Fabricantes> FabricantesList { get; set; }

        /// <summary>Gets or sets the marcas list.</summary>
        public IEnumerable<Marcas> MarcasList { get; set; }
    }
}