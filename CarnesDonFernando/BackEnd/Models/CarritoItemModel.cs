namespace BackEnd.Models
{
    public class CarritoItemModel
    {
        public int IdCarritoItems { get; set; }
        public int IdCarrito { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public string idUsuario { get; set; }
    }
}
