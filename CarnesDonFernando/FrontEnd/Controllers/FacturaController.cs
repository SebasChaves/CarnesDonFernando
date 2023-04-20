using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class FacturaController : Controller
    {
        CarritoItemsHelper carritoItemsHelper = new CarritoItemsHelper();
        CarritoHelper carritoHelper = new CarritoHelper();
        ProductoHelper productoHelper = new ProductoHelper();
        FacturaHelper facturaHelper = new FacturaHelper();
        FacturaDetalleHelper facturaDetalleHelper = new FacturaDetalleHelper();

        Decimal precioFinal = 0;

        // GET: FacturaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("userId") is not null)
            {
                List<CarritoItemViewModel> lista = carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito);
                List<ProductoViewModel> productos = new List<ProductoViewModel>();
                CarritoViewModel carritoCompuesto = carritoHelper.SetUsuario(HttpContext.Session.GetString("userId"));
                this.precioFinal = carritoCompuesto.PrecioFinal;

                foreach (var producto in lista)
                {
                    productos.Add(productoHelper.Get(producto.IdProducto));
                }

                var viewModel = new FacturaCarritoItemViewModelCompuesto { CarritoItems = lista, Producto = productos, Carrito = carritoCompuesto, Factura = new FacturaViewModel() };

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(String nombreUsuario, String apellidoUsuario, String telefonoUsuario, String cedulaUsuario, String direccionUsuario, String correoUsuario)
        {
            try
            {
                if (HttpContext.Session.GetString("userId") is not null)
                {
                    List<CarritoItemViewModel> lista = carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito);

                    FacturaViewModel facturaViewModel = new FacturaViewModel
                    {
                        ApellidoUsuario = apellidoUsuario,
                        CedulaUsuario = cedulaUsuario,
                        CorreoUsuario = correoUsuario,
                        DireccionUsuario = direccionUsuario,
                        EstadoFactura = "Por pagar",
                        IdUsuario = HttpContext.Session.GetString("userId"),
                        NombreUsuario = nombreUsuario,
                        TelefonoUsuario = telefonoUsuario,
                        FechaCreado = DateTime.Now,
                        PrecioFinal = carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).PrecioFinal

                    };
                    /*string to = HttpContext.Session.GetString("token");
                    facturaHelper = new FacturaHelper(HttpContext.Session.GetString("token"));*/
                    facturaHelper.Create(facturaViewModel);
                   int idFactura = facturaHelper.GetAll().Last().IdFactura;

                    foreach (var carritoItem in lista)
                    {
                        FacturaDetalleViewModel facturaDetalleViewModel = new FacturaDetalleViewModel
                        {
                            IdFactura = idFactura,
                            Cantidad = carritoItem.Cantidad,
                            IdProducto = carritoItem.IdProducto,
                            Precio = carritoItem.Precio
                        };
                        facturaDetalleHelper.Create(facturaDetalleViewModel);
                    }


                    List<CarritoItemViewModel> listaEliminar = carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito);

                    foreach (var item in listaEliminar)
                    {
                        carritoItemsHelper.Delete(item.IdCarritoItems);
                    }

                    carritoHelper.Delete(carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
