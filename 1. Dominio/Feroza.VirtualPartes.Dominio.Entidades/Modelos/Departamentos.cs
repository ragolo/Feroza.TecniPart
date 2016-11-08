namespace Feroza.VirtualPartes.Dominio.Entidades.Modelos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Departamentos
    {
        public Departamentos()
        {
            this.Ciudades = new List<Ciudades>();
        }

        [Key]
        public int IdDepartamentos { get; set; }
        public string CodigoDian { get; set; }
        public int IdPais { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Ciudades> Ciudades { get; set; }
        public virtual Paises Paises { get; set; }
    }
}
