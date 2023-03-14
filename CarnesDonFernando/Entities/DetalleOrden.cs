using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class DetalleOrden
    {
        public int IdOrden { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
