// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SistemasViewModel.cs" company="Feroza">
//   

// </copyright>
// <summary>
//   Defines the SistemasViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Models
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos.Productos;

    /// <summary>The fabricantes view model.</summary>
    public class SistemasViewModel : Sistemas
    {
        /// <summary>Initializes a new instance of the <see cref="SistemasViewModel"/> class.</summary>
        public SistemasViewModel()
        {
            this.TiposSistemasList = new List<Sistemas>();
        }

        public IEnumerable<Sistemas> TiposSistemasList { get; set; }
    }
}