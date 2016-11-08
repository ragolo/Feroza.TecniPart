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
    public class ReferenciasViewModel : Referencias
    {
        /// <summary>Initializes a new instance of the <see cref="ReferenciasViewModel"/> class. Initializes a new instance of the <see cref="VehiculosViewModel"/> class.</summary>
        public ReferenciasViewModel()
        {
            this.MarcasList = new List<Marcas>();
        }

        /// <summary>Gets or sets the marcas list.</summary>
        public IEnumerable<Marcas> MarcasList { get; set; }

        /// <summary>Gets or sets the sistemas list.</summary>
        public IEnumerable<Sistemas> SistemasList { get; set; }

        /// <summary>Gets or sets the sub sistemas list.</summary>
        public IEnumerable<SubSistemas> SubSistemasList { get; set; }
    }
}