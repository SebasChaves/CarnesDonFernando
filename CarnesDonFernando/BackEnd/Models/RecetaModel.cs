namespace BackEnd.Models
{
    public class RecetaModel
    {
        public int IdReceta { get; set; }
        public int IdIngrediente { get; set; }
        public string NombreReceta { get; set; } = null!;
        public string DescripcionReceta { get; set; } = null!;

    }
}



