// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sistemas.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Sistemas type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;

    /// <summary>
    /// The sistemas.
    /// </summary>
    public class Sistemas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sistemas"/> class.
        /// </summary>
        public Sistemas()
        {
            this.Catalogos = new HashSet<Catalogos>();
            this.SubSistemas = new HashSet<SubSistemas>();
        }

        /// <summary>
        /// Gets or sets the identifier sistemas.
        /// </summary>
        /// <value>
        /// The identifier sistemas.
        /// </value>
        public int IdSistemas { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>
        /// The descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the posicion.
        /// </summary>
        /// <value>
        /// The posicion.
        /// </value>
        public int Posicion { get; set; }

        /// <summary>
        /// Gets or sets the identifier estado maestras.
        /// </summary>
        /// <value>
        /// The identifier estado maestras.
        /// </value>
        public int IdEstadoMaestras { get; set; }

        /// <summary>
        /// Gets or sets the catalogos.
        /// </summary>
        /// <value>
        /// The catalogos.
        /// </value>
        public virtual ICollection<Catalogos> Catalogos { get; set; }

        /// <summary>
        /// Gets or sets the estado maestras.
        /// </summary>
        /// <value>
        /// The estado maestras.
        /// </value>
        public virtual EstadoMaestras EstadoMaestras { get; set; }

        /// <summary>
        /// Gets or sets the sub sistemas.
        /// </summary>
        /// <value>
        /// The sub sistemas.
        /// </value>
        public virtual ICollection<SubSistemas> SubSistemas { get; set; }
    }
}