using System;
using System.Collections.Generic;

namespace BackEnd
{
    public partial class FacturaModel
    {

        public int IdFactura { get; set; }
        public DateTime FechaCreado { get; set; }
        public string IdUsuario { get; set; } = null!;
        public decimal PrecioFinal { get; set; }
        public string EstadoFactura { get; set; } = null!;

    }
}
