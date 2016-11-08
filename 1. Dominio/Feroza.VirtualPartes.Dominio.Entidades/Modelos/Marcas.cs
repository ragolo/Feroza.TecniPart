// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Marcas.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Marcas type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Productos;

    /// <summary>
    /// The marcas.
    /// </summary>
    public class Marcas
    {
        public Marcas()
        {
            this.MarcasTiposProductos = new List<MarcasTiposProductos>();
        }

        [Key]
        public int IdMarcas { get; set; }

        public int IdFabricantes { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Sigla { get; set; }

        public byte[] Imagen { get; set; }

        public virtual Fabricantes Fabricantes { get; set; }

        public virtual ICollection<MarcasTiposProductos> MarcasTiposProductos { get; set; }
    }
}