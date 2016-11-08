namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos.Referencias
{
    using System.ComponentModel.DataAnnotations;

    using Productos;

    /// <summary>The referencias.</summary>
    public class Referencias
    {
        [Key]
        public int IdReferencias { get; set; }

        public int IdMarcasTiposProductos { get; set; }

        public string CodigoOEM { get; set; }

        public string CodigoFabricacion { get; set; }

        public string ReferenciaVP { get; set; }

        public bool EsKit { get; set; }

        public string Descripcion { get; set; }

        public string DescripcionTecnica { get; set; }

        public byte[] Imagen { get; set; }

        public int Cantidad { get; set; }

        public int? IdUnidadesMedidas { get; set; }

        public virtual MarcasTiposProductos MarcasTiposProductos { get; set; }
    }
}
