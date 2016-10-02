// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fabricantes.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Fabricantes type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;

    /// <summary>
    /// The fabricantes.
    /// </summary>
    public class Fabricantes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fabricantes"/> class.
        /// </summary>
        public Fabricantes()
        {
            this.Vehiculos = new HashSet<Vehiculos>();
        }

        /// <summary>
        /// Gets or sets the identifier fabricantes.
        /// </summary>
        /// <value>
        /// The identifier fabricantes.
        /// </value>
        public int IdFabricantes { get; set; }

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
        /// Gets or sets the imagen fabricante.
        /// </summary>
        /// <value>
        /// The imagen fabricante.
        /// </value>
        public byte[] ImagenFabricante { get; set; }

        /// <summary>Gets or sets the imagen fabricante base 64.</summary>
        public string ImagenFabricanteBase64 { get; set; }

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
        /// Gets or sets the pais.
        /// </summary>
        /// <value>
        /// The pais.
        /// </value>
        public virtual Pais Pais { get; set; }

        /// <summary>
        /// Gets or sets the vehiculos.
        /// </summary>
        /// <value>
        /// The vehiculos.
        /// </value>
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
    }
}