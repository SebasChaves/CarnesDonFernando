using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CategoriaController : Controller
    {
      
            CategoriaHelper categoriaHelper;


            public ActionResult Index()
            {

                categoriaHelper = new CategoriaHelper();
                List<CategoriaViewModel> lista = categoriaHelper.GetAll();

                return View(lista);
            }


            public ActionResult Details(int id)
            {
                categoriaHelper = new CategoriaHelper();
                CategoriaViewModel categoria = categoriaHelper.Get(id);

                return View(categoria);
            }


            public ActionResult Create()
            {

                return View();
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(CategoriaViewModel categoria)
            {
                try
                {
                    categoriaHelper = new CategoriaHelper();
                    categoria = categoriaHelper.Create(categoria);

                    return RedirectToAction("Details", new { id = categoria.IdCategoria });
                }
                catch
                {
                    return View();
                }
            }


            public ActionResult Edit(int id)
            {
                categoriaHelper = new CategoriaHelper();
                CategoriaViewModel ingrediente = categoriaHelper.Get(id);

                return View(ingrediente);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(CategoriaViewModel categoria)
            {
                try
                {
                    CategoriaHelper categoriaHelper = new CategoriaHelper();
                    categoria = categoriaHelper.Edit(categoria);


                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }


            public ActionResult Delete(int id)
            {
                categoriaHelper = new CategoriaHelper();
                CategoriaViewModel categoria = categoriaHelper.Get(id);

                return View(categoria);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(CategoriaViewModel categoria)
            {
                try
                {
                    categoriaHelper = new CategoriaHelper();
                    categoriaHelper.Delete(categoria.IdCategoria);


                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        }
    
}
