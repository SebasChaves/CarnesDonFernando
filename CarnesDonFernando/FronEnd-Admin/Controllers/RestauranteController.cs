using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class RestauranteController : Controller
    {
        RestauranteHelper restauranteHelper = new RestauranteHelper();

        // GET: RestauranteController
        public ActionResult Index()
        {
            List<RestauranteViewModel> lista = restauranteHelper.GetAll();

            return View(lista);
        }

        // GET: RestauranteController/Details/5
        public ActionResult Details(int id)
        {
            RestauranteViewModel restaurante = restauranteHelper.Get(id);

            return View(restaurante);
        }

        // GET: RestauranteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestauranteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestauranteViewModel restaurante)
        {
            try
            {
                restaurante = restauranteHelper.Create(restaurante);

                return RedirectToAction("Details", new { id = restaurante.IdRestaurante});
            }
            catch
            {
                return View();
            }
        }

        // GET: RestauranteController/Edit/5
        public ActionResult Edit(int id)
        {
            RestauranteViewModel restaurante = restauranteHelper.Get(id);

            return View(restaurante);
        }

        // POST: RestauranteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RestauranteViewModel restaurante)
        {
            try
            {
                restaurante = restauranteHelper.Edit(restaurante);

                return RedirectToAction("Details", new { id = restaurante.IdRestaurante });
            }
            catch
            {
                return View();
            }
        }

        // GET: RestauranteController/Delete/5
        public ActionResult Delete(int id)
        {
            RestauranteViewModel restaurante = restauranteHelper.Get(id);

            return View(restaurante);
        }

        // POST: RestauranteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RestauranteViewModel restaurante)
        {
            try
            {
                restauranteHelper.Delete(restaurante.IdRestaurante);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
