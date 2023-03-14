using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class MensajesContactoModel
    {

        public int IdMensaje { get; set; }
        public string NombrePersona { get; set; } = null!;
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int IdLocal { get; set; }
        public string Mensaje { get; set; } = null!;

    }
}
