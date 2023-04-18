
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Nombre del producto")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo solo puede contener números")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Descripcion del producto")]
        public string DescripcionProductoLarga { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Unidad de medida")]
        public string DescripcionProductoCorta { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo solo puede contener números")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Url del producto")]
        public string UrlImg { get; set; } = null!;
    }
    
}
