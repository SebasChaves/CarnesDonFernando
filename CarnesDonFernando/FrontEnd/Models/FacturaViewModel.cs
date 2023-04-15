using System;
using System.Collections.Generic;

namespace FrontEnd
{
    public partial class FacturaViewModel
    {

        public int IdFactura { get; set; }
        public DateTime FechaCreado { get; set; }
        public string IdUsuario { get; set; } = null!;
        public decimal PrecioFinal { get; set; }
        public string EstadoFactura { get; set; } = null!;

    }
}
