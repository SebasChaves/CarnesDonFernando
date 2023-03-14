using Entities;

namespace BackEnd.Models
{
    public class RecetaModel
    {
        public int IdReceta { get; set; }
        public string NombreReceta { get; set; } = null!;
        public string UrlImg { get; set; } = null!;
        public string DescripcionReceta { get; set; } = null!;

       // public virtual ICollection<Ingrediente> Ingredientes { get; set; }

    }
}



