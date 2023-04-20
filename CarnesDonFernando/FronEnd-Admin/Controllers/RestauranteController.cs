using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class RestauranteController : Controller
    {
        RestauranteHelper restauranteHelper;

        // GET: RestauranteController
        public ActionResult Index()
        {
            restauranteHelper = new RestauranteHelper();
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
            if (HttpContext.Session.GetString("role") is not null)
            {
                if (HttpContext.Session.GetString("role").Equals("Admin"))
                {
                    return View();
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

        // POST: RestauranteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestauranteViewModel restaurante)
        {
            try
            {
                if (HttpContext.Session.GetString("role") is not null)
                {
                    if (HttpContext.Session.GetString("role").Equals("Admin"))
                    {
                        restauranteHelper = new RestauranteHelper(HttpContext.Session.GetString("token"));
                        restaurante = restauranteHelper.Create(restaurante);
                        return RedirectToAction(nameof(Index));
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

        // GET: RestauranteController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("role") is not null)
            {
                if (HttpContext.Session.GetString("role").Equals("Admin"))
                {
                    restauranteHelper = new RestauranteHelper(HttpContext.Session.GetString("token"));
                    RestauranteViewModel local = restauranteHelper.Get(id);
                    return View(local);
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

        // POST: RestauranteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RestauranteViewModel restaurante)
        {
            try
            {
                if (HttpContext.Session.GetString("role") is not null)
                {
                    if (HttpContext.Session.GetString("role").Equals("Admin"))
                    {
                        restauranteHelper = new RestauranteHelper(HttpContext.Session.GetString("token"));
                        restaurante = restauranteHelper.Edit(restaurante);
                        return RedirectToAction(nameof(Index));
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

        // GET: RestauranteController/Delete/5
       /* public ActionResult Delete(int id)
        {
            RestauranteViewModel restaurante = restauranteHelper.Get(id);

            return View(restaurante);
        }*/

        // POST: RestauranteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int idRestaurante)
        {
            try
            {
                if (HttpContext.Session.GetString("role") is not null)
                {
                    if (HttpContext.Session.GetString("role").Equals("Admin"))
                    {
                        restauranteHelper = new RestauranteHelper(HttpContext.Session.GetString("token"));
                        restauranteHelper.Delete(idRestaurante);
                        return RedirectToAction(nameof(Index));
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
    }
}
