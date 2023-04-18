using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontEnd.Controllers
{
    public class ProductoController : Controller
    {
        ProductoHelper productoHelper;
        CategoriaHelper categoriaHelper = new CategoriaHelper();

        private List<SelectListItem> dropdownCreate()
        {
            List<CategoriaViewModel> lista = categoriaHelper.GetAll();

            List<SelectListItem> listaCategorias = new();

            for (int i = 0; i < lista.Count; i++)
            {
                listaCategorias.Add(new SelectListItem { Value = lista[i].IdCategoria.ToString(), Text = lista[i].Nombre.ToString() });
            }

            return listaCategorias;
        }

        // GET: ProductoController
        public ActionResult Index(int id)
        {

            productoHelper = new ProductoHelper();
            List<ProductoViewModel> lista = productoHelper.GetProductos(id);
            
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
            List<CategoriaViewModel> lista = categoriaHelper.GetAll();



            ViewBag.idCategorias = dropdownCreate();


            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel producto)
        {
            try
            {
                if (HttpContext.Session.GetString("role") is not null)
                {
                    if (HttpContext.Session.GetString("role").Equals("Admin"))
                    {
                        productoHelper = new ProductoHelper(HttpContext.Session.GetString("token"));
                        producto = productoHelper.Create(producto);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Usuario");
                }
                
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
       /* public ActionResult Delete(int id)
        {
            productoHelper = new ProductoHelper();
            ProductoViewModel producto = productoHelper.Get(id);

            return View(producto);
        }*/

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string idproducto)
        {
            try
            {
                productoHelper = new ProductoHelper();
            //    productoHelper.Delete(idproducto);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CompraProducto(int id)
        {
            productoHelper = new ProductoHelper();
            ProductoViewModel producto = productoHelper.Get(id);

            return View(producto);
        }

       
    }
}
