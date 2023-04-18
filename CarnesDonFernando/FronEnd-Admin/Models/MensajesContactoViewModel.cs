using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class MensajesContactoViewModel
    {
        public int IdMensaje { get; set; }

        [Required(ErrorMessage ="Debe especificar un nombre")]
        [Display(Name = "Nombre de la persona")]
        [StringLength(50)]
        public string NombrePersona { get; set; } = null!;

        [Required(ErrorMessage = "Debe especificar un correo")]
        [EmailAddress(ErrorMessage = "Debe especificar un correo valido")]
        public string? Correo { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números en este campo.")]
        [StringLength(8, ErrorMessage = "Debe especificar un telefono valido")]
        [Phone(ErrorMessage = "Debe especificar un telefono valido")]
        [MinLength(8,ErrorMessage = "Debe especificar un telefono valido")]
        public string? Telefono { get; set; }

        [Required]
        [Display(Name = "Nombre del local")]
        public int IdLocal { get; set; }

        [Required(ErrorMessage = "Debe especificar un mensaje")]
        [StringLength(500)]
        public string Mensaje { get; set; } = null!;

    }
}
