// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Marcas.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Marcas type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;

    /// <summary>
    /// The marcas.
    /// </summary>
    public class Marcas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Marcas" /> class.
        /// </summary>
        public Marcas()
        {
            this.Vehiculos = new HashSet<Productos>();
        }

        /// <summary>
        /// Gets or sets the identifier marcas.
        /// </summary>
        /// <value>
        /// The identifier marcas.
        /// </value>
        public int IdMarcas { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>
        /// The descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the sigla.
        /// </summary>
        /// <value>
        /// The sigla.
        /// </value>
        public string Sigla { get; set; }

        /// <summary>
        /// Gets or sets the identifier estado maestras.
        /// </summary>
        /// <value>
        /// The identifier estado maestras.
        /// </value>
        public int IdEstadoMaestras { get; set; }

        /// <summary>
        /// Gets or sets the estado maestras.
        /// </summary>
        /// <value>
        /// The estado maestras.
        /// </value>
        public virtual EstadoMaestras EstadoMaestras { get; set; }

        /// <summary>
        /// Gets or sets the vehiculos.
        /// </summary>
        /// <value>
        /// The vehiculos.
        /// </value>
        public virtual ICollection<Productos> Vehiculos { get; set; }
    }
}