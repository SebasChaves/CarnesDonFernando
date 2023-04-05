using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Carrito
    {
        public Carrito()
        {
            CarritoItems = new HashSet<CarritoItem>();
        }

        public int IdCarrito { get; set; }
        public DateTime FechaCreado { get; set; }
        public int IdUsuario { get; set; }
        public decimal PrecioFinal { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<CarritoItem> CarritoItems { get; set; }
    }
}
