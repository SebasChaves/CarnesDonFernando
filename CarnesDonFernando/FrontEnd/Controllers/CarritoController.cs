using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CarritoController : Controller
    {
        ProductoHelper productoHelper = new ProductoHelper();
        UsuarioHelper usuarioHelper = new UsuarioHelper();
        CarritoHelper carritoHelper = new CarritoHelper();
        CarritoItemsHelper carritoItemsHelper = new CarritoItemsHelper();

        int idCarritoUsuario = 0;
        int idUsuarioSession = 1;

        // GET: CarritoController
        public ActionResult Index(int idUsuario)
        {
            idCarritoUsuario = carritoHelper.SetUsuario(idUsuario).IdCarrito;

            carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(idUsuario).IdCarrito);
            List<CarritoItemViewModel> lista = carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(idUsuario).IdCarrito);
            List<ProductoViewModel> productos = new List<ProductoViewModel>();
            CarritoViewModel carritoCompuesto = carritoHelper.SetUsuario(idUsuario);

            foreach (var producto in lista)
            {
                productos.Add(productoHelper.Get(producto.IdProducto));
            }
            
            var viewModel = new ProductoCarritoViewModelCompuesto { Productos = productos, CarritoItems = lista, Carrito = carritoCompuesto };

            return View(viewModel);
        }

        // GET: CarritoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarritoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CarritoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarritoController/Edit/5
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

        // GET: CarritoController/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: CarritoController/Delete/5
       
        public ActionResult Delete(int id)
        {
            try
            {
                carritoItemsHelper.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult DeleteAll()
        {
            try
            {
                List<CarritoItemViewModel> lista = carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(idUsuarioSession).IdCarrito);

                foreach (var item in lista)
                {
                    carritoItemsHelper.Delete(item.IdCarritoItems);
                }

                //carritoItemsHelper.Delete(3);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AgregarCarrito(int idProducto, int cantidadProducto)
        {
            this.idCarritoUsuario = carritoHelper.SetUsuario(1).IdCarrito;

            int precioFinal = productoHelper.Get(idProducto).Precio * cantidadProducto;
            CarritoItemViewModel model = new CarritoItemViewModel
            {
                IdCarrito = this.idCarritoUsuario,
                IdProducto = idProducto,
                Cantidad = cantidadProducto,
                Precio = precioFinal
            };

            carritoItemsHelper.Create(model);


            return RedirectToAction(nameof(Index), new { idUsuario = idUsuarioSession });
        }

        [HttpPost]
        public ActionResult ActualizaCarrito(int idProducto, int cantidadProducto, int idCarritoItem)
        {
            this.idCarritoUsuario = carritoHelper.SetUsuario(1).IdCarrito;

            int precioFinal = productoHelper.Get(idProducto).Precio * cantidadProducto;
            CarritoItemViewModel model = new CarritoItemViewModel
            {
                IdCarrito = this.idCarritoUsuario,
                IdProducto = idProducto,
                Cantidad = cantidadProducto,
                Precio = precioFinal,
                IdCarritoItems = idCarritoItem
            };

            carritoItemsHelper.Edit(model);


            return RedirectToAction(nameof(Index), new { idUsuario = idUsuarioSession });
        }
    }
}
