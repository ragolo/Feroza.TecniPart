namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Paises
    {
        public Paises()
        {
            this.Departamentos = new List<Departamentos>();
            this.Fabricantes = new List<Fabricantes>();
        }

        [Key]
        public int IdPaises { get; set; }

        public string Codigo { get; set; }

        public string CodigoDian { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<Departamentos> Departamentos { get; set; }
       
        public virtual ICollection<Fabricantes> Fabricantes { get; set; }
    }
}
