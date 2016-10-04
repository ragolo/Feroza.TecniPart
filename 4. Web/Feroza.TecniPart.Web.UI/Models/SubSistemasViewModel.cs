// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubSistemasViewModel.cs" company="Newshore">
//   Newshore
// </copyright>
// <summary>
//   Defines the SubSistemasViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Models
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;

    /// <summary>The sub sistemas view model.</summary>
    public class SubSistemasViewModel : SubSistemas
    {
        /// <summary>Gets or sets the sistemas list.</summary>
        public IEnumerable<Sistemas> SistemasList { get; set; }
    }
}