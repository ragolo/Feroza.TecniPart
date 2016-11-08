namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos.Referencias
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>The consecutivos paises oem.</summary>
    [Table("ConsecutivosPaisesOEM")]
    public class ConsecutivosPaisesOEM
    {
        /// <summary>Gets or sets the codigo oem.</summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string CodigoOEM { get; set; }

        /// <summary>Gets or sets the id paises.</summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPaises { get; set; }

        /// <summary>Gets or sets the consecutivo.</summary>
        public short Consecutivo { get; set; }
    }
}