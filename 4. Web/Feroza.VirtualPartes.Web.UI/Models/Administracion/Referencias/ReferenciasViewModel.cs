// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductosViewModel.cs" company="Feroza">
//   

// </copyright>
// <summary>
//   Defines the ProductosViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Models.Administracion.Referencias
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;

    using Dominio.Entidades.Modelos.Referencias;

    /// <summary>The fabricantes view model.</summary>
    public class ReferenciasViewModel : Referencias
    {
        /// <summary>Initializes a new instance of the <see cref="ReferenciasViewModel"/> class.</summary>
        public ReferenciasViewModel()
        {
            this.MarcasList = new List<Marcas>();
        }

        /// <summary>Gets or sets the marcas list.</summary>
        public IEnumerable<Marcas> MarcasList { get; set; }

        /// <summary>Gets or sets the marcas tipos productos relacionados.</summary>
        public IEnumerable<ListaMarcasRelacionMarcasTiposProductosViewModel> MarcasTiposProductosRelacionados { get; set; }
    }
}