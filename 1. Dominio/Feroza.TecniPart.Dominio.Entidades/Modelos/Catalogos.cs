// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Catalogos.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Catalogos type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;

    /// <summary>
    /// The catalogos.
    /// </summary>
    public class Catalogos
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Catalogos"/> class.
        /// </summary>
        public Catalogos()
        {
            this.CatalogoDetalles = new HashSet<CatalogoDetalles>();
        }

        /// <summary>
        /// Gets or sets the identifier catalogos.
        /// </summary>
        /// <value>
        /// The identifier catalogos.
        /// </value>
        public long IdCatalogos { get; set; }

        /// <summary>
        /// Gets or sets the identifier vehiculos.
        /// </summary>
        /// <value>
        /// The identifier vehiculos.
        /// </value>
        public int IdVehiculos { get; set; }

        /// <summary>
        /// Gets or sets the identifier sistemas.
        /// </summary>
        /// <value>
        /// The identifier sistemas.
        /// </value>
        public int IdSistemas { get; set; }

        /// <summary>
        /// Gets or sets the identifier sub sistemas.
        /// </summary>
        /// <value>
        /// The identifier sub sistemas.
        /// </value>
        public int IdSubSistemas { get; set; }

        /// <summary>
        /// Gets or sets the imagen catalogo.
        /// </summary>
        /// <value>
        /// The imagen catalogo.
        /// </value>
        public byte[] ImagenCatalogo { get; set; }

        /// <summary>
        /// Gets or sets the catalogo detalles.
        /// </summary>
        /// <value>
        /// The catalogo detalles.
        /// </value>
        public virtual ICollection<CatalogoDetalles> CatalogoDetalles { get; set; }

        /// <summary>
        /// Gets or sets the sistemas.
        /// </summary>
        /// <value>
        /// The sistemas.
        /// </value>
        public virtual Sistemas Sistemas { get; set; }

        /// <summary>
        /// Gets or sets the sub sistemas.
        /// </summary>
        /// <value>
        /// The sub sistemas.
        /// </value>
        public virtual SubSistemas SubSistemas { get; set; }

        /// <summary>
        /// Gets or sets the vehiculos.
        /// </summary>
        /// <value>
        /// The vehiculos.
        /// </value>
        public virtual Vehiculos Vehiculos { get; set; }
    }
}