using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FrontEnd.Controllers
{
    public class ProductoController : Controller
    {
        ProductoHelper productoHelper;

        // GET: ProductoController
        public ActionResult Index()
        {

            productoHelper = new ProductoHelper();
            List<ProductoViewModel> lista = productoHelper.GetAll();

            return View(lista);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            productoHelper = new ProductoHelper();
            ProductoViewModel producto = productoHelper.Get(id);

            return View(producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel producto)
        {
            try
            {
                productoHelper = new ProductoHelper();
                producto = productoHelper.Create(producto);

                return RedirectToAction("Details", new { id = producto.IdProducto });
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            productoHelper = new ProductoHelper();
            ProductoViewModel producto = productoHelper.Get(id);

            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel producto)
        {
            try
            {
                ProductoHelper productoHelper = new ProductoHelper();
                producto = productoHelper.Edit(producto);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            productoHelper = new ProductoHelper();
            ProductoViewModel producto = productoHelper.Get(id);

            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductoViewModel producto)
        {
            try
            {
                productoHelper = new ProductoHelper();
                productoHelper.Delete(producto.IdProducto);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
