using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class MensajesContacto
    {
        public int IdMensaje { get; set; }
        public string NombrePersona { get; set; } = null!;
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int IdLocal { get; set; }
        public string Mensaje { get; set; } = null!;

        public virtual Local IdLocalNavigation { get; set; } = null!;
    }
}
