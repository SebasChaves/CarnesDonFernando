using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class LocalViewModel
    {
        [Required]
        [Display(Name = "Id del local")]
        public int IdLocal { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Nombre de la tienda")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres.")]
        public string NombreLocal { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Ubicacion de la tienda")]
        [StringLength(50, ErrorMessage = "El campo no debe tener más de 50 caracteres.")]
        public string Ubicacion { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Horario de la tienda")]
        [StringLength(50, ErrorMessage = "El campo no debe tener más de 50 caracteres.")]
        public string Horario { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Display(Name = "Url de la tienda")]
        public string UrlImg { get; set; } = null!;

        
        [MinLength(8, ErrorMessage = "Debe especificar un telefono valido")]
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Telefono { get; set; } = null!;
    }
}
