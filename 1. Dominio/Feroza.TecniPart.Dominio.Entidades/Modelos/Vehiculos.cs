// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vehiculos.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Vehiculos type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;

    /// <summary>
    /// The vehiculos.
    /// </summary>
    public class Vehiculos
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehiculos"/> class.
        /// </summary>
        public Vehiculos()
        {
            this.Aplicaciones = new HashSet<Aplicaciones>();
            this.Catalogos = new HashSet<Catalogos>();
        }

        /// <summary>
        /// Gets or sets the identifier vehiculos.
        /// </summary>
        /// <value>
        /// The identifier vehiculos.
        /// </value>
        public int IdVehiculos { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>
        /// The descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the imagen vehiculo.
        /// </summary>
        /// <value>
        /// The imagen vehiculo.
        /// </value>
        public byte[] ImagenVehiculo { get; set; }

        /// <summary>
        /// Gets or sets the identifier fabricantes.
        /// </summary>
        /// <value>
        /// The identifier fabricantes.
        /// </value>
        public int IdFabricantes { get; set; }

        /// <summary>
        /// Gets or sets the identifier marca.
        /// </summary>
        /// <value>
        /// The identifier marca.
        /// </value>
        public int IdMarca { get; set; }

        /// <summary>
        /// Gets or sets the ango.
        /// </summary>
        /// <value>
        /// The ango.
        /// </value>
        public string Ango { get; set; }

        /// <summary>
        /// Gets or sets the comentario.
        /// </summary>
        /// <value>
        /// The comentario.
        /// </value>
        public string Comentario { get; set; }

        /// <summary>
        /// Gets or sets the aplicaciones.
        /// </summary>
        /// <value>
        /// The aplicaciones.
        /// </value>
        public virtual ICollection<Aplicaciones> Aplicaciones { get; set; }

        /// <summary>
        /// Gets or sets the catalogos.
        /// </summary>
        /// <value>
        /// The catalogos.
        /// </value>
        public virtual ICollection<Catalogos> Catalogos { get; set; }

        /// <summary>
        /// Gets or sets the fabricantes.
        /// </summary>
        /// <value>
        /// The fabricantes.
        /// </value>
        public virtual Fabricantes Fabricantes { get; set; }

        /// <summary>
        /// Gets or sets the marcas.
        /// </summary>
        /// <value>
        /// The marcas.
        /// </value>
        public virtual Marcas Marcas { get; set; }
    }
}