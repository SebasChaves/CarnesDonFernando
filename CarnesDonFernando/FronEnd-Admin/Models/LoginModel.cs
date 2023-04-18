using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Debe ingresar el nombre de usuario")]
        [RegularExpression("^[^\\s]*$", ErrorMessage = "No se permiten espacios en este campo.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        [RegularExpression("^[^\\s]*$", ErrorMessage = "No se permiten espacios en este campo.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
