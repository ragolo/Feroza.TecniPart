// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Referencias.cs" company="">
//   
// </copyright>
// <summary>
//   The referencias.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The referencias.
    /// </summary>
    public class Referencias
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Referencias"/> class.
        /// </summary>
        public Referencias()
        {
            this.Aplicaciones = new HashSet<Aplicaciones>();
        }

        /// <summary>
        /// Gets or sets the codigo oem.
        /// </summary>
        /// <value>
        /// The codigo oem.
        /// </value>
        public string CodigoOem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Referencias"/> is kit.
        /// </summary>
        /// <value>
        ///   <c>true</c> if kit; otherwise, <c>false</c>.
        /// </value>
        public bool Kit { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>
        /// The descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the descripcion tecnica.
        /// </summary>
        /// <value>
        /// The descripcion tecnica.
        /// </value>
        public string DescripcionTecnica { get; set; }

        /// <summary>
        /// Gets or sets the identifier fabricante.
        /// </summary>
        /// <value>
        /// The identifier fabricante.
        /// </value>
        public Nullable<int> IdFabricante { get; set; }

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
        /// Gets or sets the codigo oem padre.
        /// </summary>
        /// <value>
        /// The codigo oem padre.
        /// </value>
        public string CodigoOemPadre { get; set; }

        /// <summary>
        /// Gets or sets the identifier marcas.
        /// </summary>
        /// <value>
        /// The identifier marcas.
        /// </value>
        public Nullable<int> IdMarcas { get; set; }

        /// <summary>
        /// Gets or sets the aplicaciones.
        /// </summary>
        /// <value>
        /// The aplicaciones.
        /// </value>
        public virtual ICollection<Aplicaciones> Aplicaciones { get; set; }

        /// <summary>Gets or sets the marcas.</summary>
        public virtual Marcas Marcas { get; set; }

        /// <summary>Gets or sets the sistemas.</summary>
        public virtual Sistemas Sistemas { get; set; }

        /// <summary>Gets or sets the sub sistemas.</summary>
        public virtual SubSistemas SubSistemas { get; set; }
    }
}