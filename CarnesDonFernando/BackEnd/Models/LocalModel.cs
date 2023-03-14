namespace BackEnd.Models
{
    public class LocalModel
    {
        public int IdLocal { get; set; }
        public string NombreLocal { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string Horario { get; set; } = null!;
        public string UrlImg { get; set; } = null!;
    }
}
