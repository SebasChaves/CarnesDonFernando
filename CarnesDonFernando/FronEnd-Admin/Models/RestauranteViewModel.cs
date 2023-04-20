using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class RestauranteViewModel
    {
        [Required]
        public int IdRestaurante { get; set; }



        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Nombre del restaurante")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres.")]
        public string NombreRestaurante { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Ubicacion del restaurante")]
        [StringLength(50, ErrorMessage = "El campo no debe tener más de 50 caracteres.")]
        public string Ubicacion { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Horario del restaurante")]
        [StringLength(50, ErrorMessage = "El campo no debe tener más de 50 caracteres.")]
        public string Horario { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Url del restaurante")]
        public string UrlImg { get; set; } = null!;

        [MinLength(8, ErrorMessage = "Debe especificar un telefono valido")]
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Telefono { get; set; } = null!;

    }
}
