using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class MensajesContactoViewModel
    {
        public int IdMensaje { get; set; }

        [Required]
        [Display(Name = "Nombre de la persona")]
        [StringLength(50)]
        public string NombrePersona { get; set; } = null!;

        [StringLength(50)]
        [EmailAddress]
        public string? Correo { get; set; }

        [StringLength(50)]
        [Phone]
        public string? Telefono { get; set; }

        [Required]
        [Display(Name = "Id del local")]
        public int IdLocal { get; set; }

        [Required]
        [StringLength(500)]
        public string Mensaje { get; set; } = null!;

    }
}
