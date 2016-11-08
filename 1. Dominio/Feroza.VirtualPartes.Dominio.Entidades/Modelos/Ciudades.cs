// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ciudades.cs" company="">
//   
// </copyright>
// <summary>
//   The ciudades.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos
{
    /// <summary>The ciudades.</summary>
    public class Ciudades
    {
        /// <summary>Gets or sets the id ciudades.</summary>
        public int IdCiudades { get; set; }

        /// <summary>Gets or sets the id departamentos.</summary>
        public int IdDepartamentos { get; set; }

        /// <summary>Gets or sets the codigo dian.</summary>
        public string CodigoDian { get; set; }

        /// <summary>Gets or sets the nombre.</summary>
        public string Nombre { get; set; }

        /// <summary>Gets or sets the departamentos.</summary>
        public virtual Departamentos Departamentos { get; set; }
    }
}