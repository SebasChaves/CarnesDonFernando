using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FrontEnd
{
    public partial class FacturaViewModel
    {

        public int IdFactura { get; set; }
        public DateTime FechaCreado { get; set; }
        public string IdUsuario { get; set; } = null!;

        [DisplayName("ggg")]
        public string NombreUsuario { get; set; } = null!;
        public string ApellidoUsuario { get; set; } = null!;
        public string CedulaUsuario { get; set; } = null!;
        public string DireccionUsuario { get; set; } = null!;
        public string TelefonoUsuario { get; set; } = null!;
        public string CorreoUsuario { get; set; } = null!;
        public decimal PrecioFinal { get; set; }
        public string EstadoFactura { get; set; } = null!;

    }
}
