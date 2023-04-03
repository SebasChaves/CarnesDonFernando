using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class LocalViewModel
    {
        [Required]
        [Display(Name = "Id del local")]
        public int IdLocal { get; set; }

        [Required]
        [Display(Name = "Nombre del local")]
        [StringLength(50)]
        public string NombreLocal { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Ubicacion { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Horario { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string UrlImg { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}
