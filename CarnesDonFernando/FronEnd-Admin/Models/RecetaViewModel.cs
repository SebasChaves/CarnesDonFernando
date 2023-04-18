using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class RecetaViewModel
    {
        [Required]
        public int IdReceta { get; set; }
        [Required]
        public string NombreReceta { get; set; } = null!;
        [Required]
        public string UrlImg { get; set; } = null!;
        [Required]
        public string DescripcionReceta { get; set; } = null!;

    }
}



