using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public class FacturaDetalleViewModel
    {
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
