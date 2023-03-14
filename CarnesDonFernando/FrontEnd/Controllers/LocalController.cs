using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class LocalController : Controller
    {
        LocalHelper localHelper= new LocalHelper();

        // GET: LocalController
        public ActionResult Index()
        {
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
            return View();
        }

        // POST: LocalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalViewModel local)
        {
            try
            {
                local = localHelper.Create(local);

                return RedirectToAction("Details", new { id = local.IdLocal});
            }
            catch
            {
                return View();
            }
        }

        // GET: LocalController/Edit/5
        public ActionResult Edit(int id)
        {
            LocalViewModel local = localHelper.Get(id);

            return View(local);
        }

        // POST: LocalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocalViewModel local)
        {
            try
            {
                local = localHelper.Edit(local);

                return RedirectToAction("Details", new { id = local.IdLocal });
            }
            catch
            {
                return View();
            }
        }

        // GET: LocalController/Delete/5
        public ActionResult Delete(int id)
        {
            LocalViewModel local = localHelper.Get(id);

            return View(local);
        }

        // POST: LocalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LocalViewModel local)
        {
            try
            {
                localHelper.Delete(local.IdLocal);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
