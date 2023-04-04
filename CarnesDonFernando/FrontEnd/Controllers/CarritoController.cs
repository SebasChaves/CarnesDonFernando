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


        // GET: CarritoController
        public ActionResult Index(int idUsuario)
        {

            carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(idUsuario).IdCarrito);
            List<CarritoItemViewModel> lista = carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(idUsuario).IdCarrito);
            List<ProductoViewModel> productos = new List<ProductoViewModel>();

            foreach (var producto in lista)
            {
                productos.Add(productoHelper.Get(producto.IdProducto));
            }
            
            var viewModel = new ProductoCarritoViewModelCompuesto { Productos = productos, CarritoItems = lista };

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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarritoController/Delete/5
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
