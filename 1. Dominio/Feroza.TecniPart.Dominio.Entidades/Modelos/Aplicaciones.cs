// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Aplicaciones.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Aplicaciones type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    /// <summary>
    /// The aplicaciones.
    /// </summary>
    public class Aplicaciones
    {
        /// <summary>
        /// Gets or sets the id aplicaciones.
        /// </summary>
        public int IdAplicaciones { get; set; }

        /// <summary>
        /// Gets or sets the identifier vehiculos.
        /// </summary>
        /// <value>
        /// The identifier vehiculos.
        /// </value>
        public int IdVehiculos { get; set; }

        /// <summary>
        /// Gets or sets the codigo oem.
        /// </summary>
        /// <value>
        /// The codigo oem.
        /// </value>
        public string CodigoOem { get; set; }

        /// <summary>
        /// Gets or sets the referencias.
        /// </summary>
        /// <value>
        /// The referencias.
        /// </value>
        public virtual Referencias Referencias { get; set; }

        /// <summary>
        /// Gets or sets the vehiculos.
        /// </summary>
        /// <value>
        /// The vehiculos.
        /// </value>
        public virtual Vehiculos Vehiculos { get; set; }
    }
}