using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña nueva")]
        public string Contrasenia { get; set; } = null!;
    }
}
