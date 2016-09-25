// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pais.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Pais type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;

    /// <summary>
    /// The pais.
    /// </summary>
    public class Pais
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pais"/> class.
        /// </summary>
        public Pais()
        {
            this.Fabricantes = new HashSet<Fabricantes>();
        }

        /// <summary>
        /// Gets or sets the identifier pais.
        /// </summary>
        /// <value>
        /// The identifier pais.
        /// </value>
        public int IdPais { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>
        /// The descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the identifier dane.
        /// </summary>
        /// <value>
        /// The identifier dane.
        /// </value>
        public int IdDane { get; set; }
        
        /// <summary>
        /// Gets or sets the fabricantes.
        /// </summary>
        /// <value>
        /// The fabricantes.
        /// </value>
        public virtual ICollection<Fabricantes> Fabricantes { get; set; }
    }
}