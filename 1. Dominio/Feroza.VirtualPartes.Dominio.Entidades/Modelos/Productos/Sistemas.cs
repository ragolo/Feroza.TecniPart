namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos.Productos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Sistemas
    {
        public Sistemas()
        {
            SistemasHijos = new List<Sistemas>();
        }

        [Key]
        public int IdSistemas { get; set; }

        public int? IdSistemasPadre { get; set; }

        public int? IdTiposProductos { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Posicion { get; set; }

        public virtual ICollection<Sistemas> SistemasHijos { get; set; }

        public virtual Sistemas Sistemas1 { get; set; }

        public virtual TiposProductos TiposProductos { get; set; }
    }
}