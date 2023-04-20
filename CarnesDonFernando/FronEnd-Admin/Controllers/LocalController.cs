using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class LocalController : Controller
    {
        LocalHelper localHelper;

        // GET: LocalController
        public ActionResult Index()
        {
            localHelper = new LocalHelper();
            List<LocalViewModel> lista = localHelper.GetAll();

            return View(lista);
        }

        // GET: LocalController/Details/5
        public ActionResult Details(int id)
        {
            LocalViewModel local = localHelper.Get(id);

            return View(local);
        }

        // GET: LocalController/Create
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

        // POST: LocalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalViewModel local)
        {
            try
            {
                if (HttpContext.Session.GetString("role") is not null)
                {
                    if (HttpContext.Session.GetString("role").Equals("Admin"))
                    {
                        localHelper = new LocalHelper(HttpContext.Session.GetString("token"));
                        local = localHelper.Create(local);
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

        // GET: LocalController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("role") is not null)
            {
                if (HttpContext.Session.GetString("role").Equals("Admin"))
                {
                    localHelper = new LocalHelper(HttpContext.Session.GetString("token"));
                    LocalViewModel local = localHelper.Get(id);
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

        // POST: LocalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocalViewModel local)
        {
            try
            {
                if (HttpContext.Session.GetString("role") is not null)
                {
                    if (HttpContext.Session.GetString("role").Equals("Admin"))
                    {
                        localHelper = new LocalHelper(HttpContext.Session.GetString("token"));
                        local = localHelper.Edit(local);
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

        // GET: LocalController/Delete/5
       /* public ActionResult Delete(int id)
        {
            LocalViewModel local = localHelper.Get(id);

            return View(local);
        }*/

        // POST: LocalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdLocal)
        {
            try
            {
                if (HttpContext.Session.GetString("role") is not null)
                {
                    if (HttpContext.Session.GetString("role").Equals("Admin"))
                    {
                        localHelper = new LocalHelper(HttpContext.Session.GetString("token"));
                        localHelper.Delete(IdLocal);
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
