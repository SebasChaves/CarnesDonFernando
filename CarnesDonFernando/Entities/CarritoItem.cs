using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class CarritoItem
    {
        public int IdCarritoItems { get; set; }
        public int IdCarrito { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public virtual Carrito IdCarritoNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
