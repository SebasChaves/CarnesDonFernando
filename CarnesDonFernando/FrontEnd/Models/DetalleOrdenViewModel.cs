using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class DetalleOrdenViewModel
    {

        public int IdOrden { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }

    }
}
