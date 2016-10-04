// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubSistemas.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the SubSistemas type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;

    /// <summary>
    /// The sub sistemas.
    /// </summary>
    public class SubSistemas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubSistemas"/> class.
        /// </summary>
        public SubSistemas()
        {
            this.Catalogos = new HashSet<Catalogos>();
            this.VehiculoSubSistemas = new HashSet<VehiculoSubSistemas>();
        }

        /// <summary>
        /// Gets or sets the identifier sub sistemas.
        /// </summary>
        /// <value>
        /// The identifier sub sistemas.
        /// </value>
        public int IdSubSistemas { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>
        /// The descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the identifier sistemas.
        /// </summary>
        /// <value>
        /// The identifier sistemas.
        /// </value>
        public int IdSistemas { get; set; }

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
        /// Gets or sets the sistemas.
        /// </summary>
        /// <value>
        /// The sistemas.
        /// </value>
        public virtual Sistemas Sistemas { get; set; }

        /// <summary>
        /// Gets or sets the vehiculo sub sistemas.
        /// </summary>
        /// <value>
        /// The vehiculo sub sistemas.
        /// </value>
        public virtual ICollection<VehiculoSubSistemas> VehiculoSubSistemas { get; set; }
    }
}