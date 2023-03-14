using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        public int IdCategoria { get; set; }
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public int Precio { get; set; }
        public string DescripcionProductoLarga { get; set; } = null!;
        public string DescripcionProductoCorta { get; set; } = null!;
        public int Cantidad { get; set; }
        public string UrlImg { get; set; } = null!;

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } 
    }
}
