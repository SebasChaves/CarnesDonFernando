namespace BackEnd.Models
{
    public class CarritoModel
    {
        public int IdCarrito { get; set; }
        public DateTime FechaCreado { get; set; }
        public string IdUsuario { get; set; } = null!;

        public decimal PrecioFinal { get; set; }
    }
}
