using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontEnd.Controllers
{
    public class IngredienteController : Controller
    {
        IngredienteHelper ingredienteHelper;
        RecetaHelper recetaHelper = new RecetaHelper();

        // GET: IngredienteController
        public ActionResult Index()
        {

            ingredienteHelper = new IngredienteHelper();
            List<IngredienteViewModel> lista = ingredienteHelper.GetAll();

            return View(lista);
        }

        // GET: IngredienteController/Details/5
        public ActionResult Details(int id)
        {
            ingredienteHelper = new IngredienteHelper();
            IngredienteViewModel ingrediente = ingredienteHelper.Get(id);

            return View(ingrediente);
        }

        // GET: IngredienteController/Create
        public ActionResult Create()
        {
            ingredienteHelper = new IngredienteHelper();
            List<RecetaViewModel> lista = recetaHelper.GetAll();            

            List<SelectListItem> listaRecetas = new();
          
            for (int i = 0;i<lista.Count;i++)
            {
                 listaRecetas.Add(new SelectListItem { Value = lista[i].IdReceta.ToString(), Text = lista[i].NombreReceta.ToString() });
            }

             
            ViewBag.idReceta = listaRecetas;


            return View();
        }

        // POST: IngredienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredienteViewModel ingrediente)
        {
            try
            {
                ingredienteHelper = new IngredienteHelper();
                ingrediente = ingredienteHelper.Create(ingrediente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredienteController/Edit/5
        public ActionResult Edit(int id)
        {
            ingredienteHelper = new IngredienteHelper();
            IngredienteViewModel ingrediente = ingredienteHelper.Get(id);

            return View(ingrediente);
        }

        // POST: IngredienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IngredienteViewModel ingrediente)
        {
            try
            {
                IngredienteHelper ingredienteHelper = new IngredienteHelper();
                ingrediente = ingredienteHelper.Edit(ingrediente);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredienteController/Delete/5
        public ActionResult Delete(int id)
        {
            ingredienteHelper = new IngredienteHelper();
            IngredienteViewModel producto = ingredienteHelper.Get(id);

            return View(producto);
        }

        // POST: IngredienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(IngredienteViewModel ingrediente)
        {
            try
            {
                ingredienteHelper = new IngredienteHelper();
                ingredienteHelper.Delete(ingrediente.IdIngrediente);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
