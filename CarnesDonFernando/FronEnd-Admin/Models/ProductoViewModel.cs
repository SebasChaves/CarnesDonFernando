
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {

        public int IdCategoria { get; set; }
        
        public int IdProducto { get; set; }

        [Required]
        [Display(Name = "Nombre del producto")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Required]
        public int Precio { get; set; }
        [Required]
        public string DescripcionProductoLarga { get; set; } = null!;
        [Required]
        public string DescripcionProductoCorta { get; set; } = null!;
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public string UrlImg { get; set; } = null!;
    }
    
}
