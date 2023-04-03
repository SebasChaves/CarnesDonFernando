using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class RestauranteViewModel
    {
        [Required]
        public int IdRestaurante { get; set; }
        [Required]
        public string NombreRestaurante { get; set; } = null!;
        [Required]
        public string Ubicacion { get; set; } = null!;
        [Required]
        public string Horario { get; set; } = null!;
        [Required]
        public string UrlImg { get; set; } = null!;
        public string Telefono { get; set; } = null!;

    }
}
