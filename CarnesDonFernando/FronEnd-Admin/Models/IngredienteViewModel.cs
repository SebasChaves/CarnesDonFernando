using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class IngredienteViewModel
    {
        [Required]
        [Display(Name = "Id del ingrediente")]
        public int IdIngrediente { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; } = null!;

        public int IdReceta { get; set; }

    }
}
