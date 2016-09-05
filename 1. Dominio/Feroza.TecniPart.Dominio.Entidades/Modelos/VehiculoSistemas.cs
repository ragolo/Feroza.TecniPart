// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculoSistemas.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the VehiculoSistemas type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;

    /// <summary>
    /// The vehiculo sistemas.
    /// </summary>
    public class VehiculoSistemas
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="VehiculoSistemas"/> class.
        /// </summary>
        public VehiculoSistemas()
        {
            this.VehiculoSubSistemas = new HashSet<VehiculoSubSistemas>();
        }

        /// <summary>
        /// Gets or sets the identifier vehiculo sistemas.
        /// </summary>
        /// <value>
        /// The identifier vehiculo sistemas.
        /// </value>
        public int IdVehiculoSistemas { get; set; }

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
        /// Gets or sets the vehiculo sub sistemas.
        /// </summary>
        /// <value>
        /// The vehiculo sub sistemas.
        /// </value>
        public virtual ICollection<VehiculoSubSistemas> VehiculoSubSistemas { get; set; }
    }
}