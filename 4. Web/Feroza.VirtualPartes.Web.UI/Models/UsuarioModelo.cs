namespace Feroza.VirtualPartes.Web.UI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UsuarioModelo
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y confirmacion de la contraseña no son iguales")]
        public string ConfirmarPassword { get; set; }
    }
}