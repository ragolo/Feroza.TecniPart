// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogoDetalles.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the CatalogoDetalles type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Entidades.Modelos
{
    /// <summary>
    /// The catalogo detalles.
    /// </summary>
    public class CatalogoDetalles
    {
        /// <summary>
        /// Gets or sets the id catalogo detalle.
        /// </summary>
        public int IdCatalogoDetalle { get; set; }

        /// <summary>
        /// Gets or sets the id item.
        /// </summary>
        public string IdItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether aplica kit.
        /// </summary>
        public bool AplicaKit { get; set; }

        /// <summary>
        /// Gets or sets the codigo.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the cantidad.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Gets or sets the id catalogos.
        /// </summary>
        public long IdCatalogos { get; set; }

        /// <summary>
        /// Gets or sets the catalogos.
        /// </summary>
        public virtual Catalogos Catalogos { get; set; }
    }
}