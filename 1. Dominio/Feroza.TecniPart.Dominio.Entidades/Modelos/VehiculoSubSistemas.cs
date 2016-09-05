// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculoSubSistemas.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the VehiculoSubSistemas type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    /// <summary>
    /// The vehiculo sub sistemas.
    /// </summary>
    public class VehiculoSubSistemas
    {
        /// <summary>
        /// Gets or sets the identifier vehiculo sub sistemas.
        /// </summary>
        /// <value>
        /// The identifier vehiculo sub sistemas.
        /// </value>
        public int IdVehiculoSubSistemas { get; set; }

        /// <summary>
        /// Gets or sets the identifier vehiculo sistemas.
        /// </summary>
        /// <value>
        /// The identifier vehiculo sistemas.
        /// </value>
        public int IdVehiculoSistemas { get; set; }

        /// <summary>
        /// Gets or sets the identifier sub sistemas.
        /// </summary>
        /// <value>
        /// The identifier sub sistemas.
        /// </value>
        public int IdSubSistemas { get; set; }

        /// <summary>
        /// Gets or sets the sub sistemas.
        /// </summary>
        /// <value>
        /// The sub sistemas.
        /// </value>
        public virtual SubSistemas SubSistemas { get; set; }

        /// <summary>
        /// Gets or sets the vehiculo sistemas.
        /// </summary>
        /// <value>
        /// The vehiculo sistemas.
        /// </value>
        public virtual VehiculoSistemas VehiculoSistemas { get; set; }
    }
}