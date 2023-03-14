using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class DetalleOrdenController : Controller
    {
        DetalleOrdenHelper detalleOrdenHelper;


        public ActionResult Index()
        {

            detalleOrdenHelper = new DetalleOrdenHelper();
            List<DetalleOrdenViewModel> lista = detalleOrdenHelper.GetAll();

            return View(lista);
        }


        public ActionResult Details(int id)
        {
            detalleOrdenHelper = new DetalleOrdenHelper();
            DetalleOrdenViewModel detalleOrden = detalleOrdenHelper.Get(id);

            return View(detalleOrden);
        }


        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleOrdenViewModel detalleOrden)
        {
            try
            {
                detalleOrdenHelper = new DetalleOrdenHelper();
                detalleOrden = detalleOrdenHelper.Create(detalleOrden);

                return RedirectToAction("Details", new { id = detalleOrden.IdProducto });
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            detalleOrdenHelper = new DetalleOrdenHelper();
            DetalleOrdenViewModel detalleOrden = detalleOrdenHelper.Get(id);

            return View(detalleOrden);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetalleOrdenViewModel detalleOrden)
        {
            try
            {
                DetalleOrdenHelper detalleOrdenHelper = new DetalleOrdenHelper();
                detalleOrden = detalleOrdenHelper.Edit(detalleOrden);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            detalleOrdenHelper = new DetalleOrdenHelper();
            DetalleOrdenViewModel detalleOrden = detalleOrdenHelper.Get(id);

            return View(detalleOrden);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DetalleOrdenViewModel detalleOrden)
        {
            try
            {
                detalleOrdenHelper = new DetalleOrdenHelper();
                detalleOrdenHelper.Delete(detalleOrden.IdProducto );


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
