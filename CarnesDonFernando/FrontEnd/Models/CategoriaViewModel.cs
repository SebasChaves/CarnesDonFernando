using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class CategoriaViewModel
    {
        [Required]
        [Display(Name = "Id de la categoria")]
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; } = null!;

    }
}
