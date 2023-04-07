using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ContraseniaModel
    {
        [Required(ErrorMessage = "Debe ingresar el nombre de usuario")]
        [RegularExpression("^[^\\s]*$", ErrorMessage = "No se permiten espacios en este campo.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$", ErrorMessage = "La cadena debe tener al menos un número, una letra mayúscula, una letra minúscula y un carácter especial.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden.")]
        public string NewPasswordConfirm { get; set; }

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        public string OldPassword { get; set; }
    }

}
