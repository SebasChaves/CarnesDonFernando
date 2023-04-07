using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Debe ingresar el nombre de usuario")]
        [RegularExpression("^[^\\s]*$", ErrorMessage = "No se permiten espacios en este campo.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe ingresar el correo")]
        [RegularExpression("^[^\\s]*$", ErrorMessage = "No se permiten espacios en este campo.")]
        [EmailAddress(ErrorMessage = "Debe especificar un correo valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$", ErrorMessage = "La cadena debe tener al menos un número, una letra mayúscula, una letra minúscula y un carácter especial.")] public string Password { get; set; }

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
