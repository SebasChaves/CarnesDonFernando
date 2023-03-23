using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class DetalleOrdenViewModel
    {
        [Required]
        [Display(Name = "Id de la orden")]
        public int IdOrden { get; set; }

        [Required]
        [Display(Name = "Id del producto")]
        public int IdProducto { get; set; }

        [Required]
        [Range(1, 100)]
        public int Cantidad { get; set; }

        [Required]
        public double Subtotal { get; set; }

        [Required]
        public double Total { get; set; }

    }
}
