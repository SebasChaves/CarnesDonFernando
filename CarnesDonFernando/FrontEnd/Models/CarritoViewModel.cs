namespace FrontEnd.Models
{
    public class CarritoViewModel
    {
        public int IdCarrito { get; set; }
        public DateTime FechaCreado { get; set; }
        public string IdUsuario { get; set; } = null!;
        public decimal PrecioFinal { get; set; }
    }
}
