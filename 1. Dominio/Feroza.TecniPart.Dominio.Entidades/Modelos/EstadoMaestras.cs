// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EstadoMaestras.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the EstadoMaestras type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;

    /// <summary>
    /// The estado maestras.
    /// </summary>
    public class EstadoMaestras
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstadoMaestras"/> class.
        /// </summary>
        public EstadoMaestras()
        {
            this.Fabricantes = new HashSet<Fabricantes>();
            this.Marcas = new HashSet<Marcas>();
            this.Pais = new HashSet<Pais>();
            this.Sistemas = new HashSet<Sistemas>();
            this.SubSistemas = new HashSet<SubSistemas>();
        }

        /// <summary>
        /// Gets or sets the identifier estado maestras.
        /// </summary>
        /// <value>
        /// The identifier estado maestras.
        /// </value>
        public int IdEstadoMaestras { get; set; }

        /// <summary>
        /// Gets or sets the desripcion.
        /// </summary>
        /// <value>
        /// The desripcion.
        /// </value>
        public string Descripcion { get; set; }


        /// <summary>
        /// Gets or sets the fabricantes.
        /// </summary>
        /// <value>
        /// The fabricantes.
        /// </value>
        public virtual ICollection<Fabricantes> Fabricantes { get; set; }

        /// <summary>
        /// Gets or sets the marcas.
        /// </summary>
        /// <value>
        /// The marcas.
        /// </value>
        public virtual ICollection<Marcas> Marcas { get; set; }

        /// <summary>
        /// Gets or sets the pais.
        /// </summary>
        /// <value>
        /// The pais.
        /// </value>
        public virtual ICollection<Pais> Pais { get; set; }

        /// <summary>
        /// Gets or sets the sistemas.
        /// </summary>
        /// <value>
        /// The sistemas.
        /// </value>
        public virtual ICollection<Sistemas> Sistemas { get; set; }

        /// <summary>
        /// Gets or sets the sub sistemas.
        /// </summary>
        /// <value>
        /// The sub sistemas.
        /// </value>
        public virtual ICollection<SubSistemas> SubSistemas { get; set; }
    }
}
