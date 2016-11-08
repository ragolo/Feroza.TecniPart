// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fabricantes.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Fabricantes type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The fabricantes.
    /// </summary>
    public class Fabricantes
    {

        /// <summary>
        /// Gets or sets the identifier fabricantes.
        /// </summary>
        /// <value>
        /// The identifier fabricantes.
        /// </value>
        [Key]
        public int IdFabricantes { get; set; }

        /// <summary>
        /// Gets or sets the identifier pais.
        /// </summary>
        /// <value>
        /// The identifier pais.
        /// </value>
        public int IdPaises { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the pais.
        /// </summary>
        /// <value>
        /// The pais.
        /// </value>
        public virtual Paises Paises { get; set; }

        /// <summary>Gets or sets the marcas.</summary>
        public virtual ICollection<Marcas> Marcas { get; set; }
    }
}