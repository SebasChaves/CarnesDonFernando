﻿using System;
using System.Collections.Generic;

namespace BackEnd
{
    public partial class FacturaDetalleModel
    {
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
