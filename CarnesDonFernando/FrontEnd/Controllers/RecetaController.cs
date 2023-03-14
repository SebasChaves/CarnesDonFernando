using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FrontEnd.Controllers
{
    public class RecetaController : Controller
    {
        RecetaHelper recetaHelper;

        // GET: RecetaController
        public ActionResult Index()
        {

            recetaHelper = new RecetaHelper();
            List<RecetaViewModel> lista = recetaHelper.GetAll();

            return View(lista);
        }

        // GET: RecetaController/Details/5
        public ActionResult Details(int id)
        {
            recetaHelper = new RecetaHelper();
            RecetaViewModel receta = recetaHelper.Get(id);

            return View(receta);
        }

        // GET: RecetaController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: RecetaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecetaViewModel receta)
        {
            try
            {
                recetaHelper = new RecetaHelper();
                receta = recetaHelper.Create(receta);

                return RedirectToAction("Details", new { id = receta.IdReceta });
            }
            catch
            {
                return View();
            }
        }

        // GET: RecetaController/Edit/5
        public ActionResult Edit(int id)
        {
            recetaHelper = new RecetaHelper();
            RecetaViewModel receta = recetaHelper.Get(id);

            return View(receta);
        }

        // POST: RecetaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RecetaViewModel receta)
        {
            try
            {
                RecetaHelper recetaHelper = new RecetaHelper();
                receta = recetaHelper.Edit(receta);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecetaController/Delete/5
        public ActionResult Delete(int id)
        {
            recetaHelper = new RecetaHelper();
            RecetaViewModel receta = recetaHelper.Get(id);

            return View(receta);
        }

        // POST: RecetaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RecetaViewModel receta)
        {
            try
            {
                recetaHelper = new RecetaHelper();
                recetaHelper.Delete(receta.IdReceta);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
