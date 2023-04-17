namespace FrontEnd.Models
{
    public class FacturaCarritoItemViewModelCompuesto
    {
        public List<CarritoItemViewModel> CarritoItems { get; set; }
        public FacturaViewModel Factura { get; set; } = null!;
        public CarritoViewModel Carrito { get; set; } 

        public List<ProductoViewModel> Producto { get; set; }
    }
}
