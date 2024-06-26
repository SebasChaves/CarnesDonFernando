﻿using System.Collections.Generic;

namespace Entities
{
    public partial class Factura
    {
        public Factura()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        public int IdFactura { get; set; }
        public DateTime FechaCreado { get; set; }
        public string IdUsuario { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string ApellidoUsuario { get; set; } = null!;
        public string CedulaUsuario { get; set; } = null!;
        public string DireccionUsuario { get; set; } = null!;
        public string TelefonoUsuario { get; set; } = null!;
        public string CorreoUsuario { get; set; } = null!;
        public decimal PrecioFinal { get; set; }
        public string EstadoFactura { get; set; } = null!;

        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
