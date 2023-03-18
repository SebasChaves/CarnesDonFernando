using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontEnd.Controllers
{
    public class MensajesContactoController : Controller
    {
        MensajesContactoHelper mensajesContactoHelper;
        LocalHelper localHelper = new LocalHelper();

        private List<SelectListItem> dropdownCreate()
        {
            List<LocalViewModel> lista = localHelper.GetAll();

            List<SelectListItem> listaLocales = new();

            for (int i = 0; i < lista.Count; i++)
            {
                listaLocales.Add(new SelectListItem { Value = lista[i].IdLocal.ToString(), Text = lista[i].NombreLocal.ToString() });
            }
            return listaLocales;
        }
        // GET: MensajesContactoController
        public ActionResult Index()
        {

            mensajesContactoHelper = new MensajesContactoHelper();
            List<MensajesContactoViewModel> lista = mensajesContactoHelper.GetAll();

            return View(lista);
        }

        // GET: MensajesContactoController/Details/5
        public ActionResult Details(int id)
        {
            mensajesContactoHelper = new MensajesContactoHelper();
            MensajesContactoViewModel mensajesContacto = mensajesContactoHelper.Get(id);    

            return View(mensajesContacto);
        }

        // GET: MensajesContactoController/Create
        public ActionResult Create()
        {
            ViewBag.idLocal = dropdownCreate();
            return View();
        }

        // POST: MensajesContactoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MensajesContactoViewModel mensajesContacto)
        {
            try
            {
                mensajesContactoHelper = new MensajesContactoHelper();
                 mensajesContacto = mensajesContactoHelper.Create(mensajesContacto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MensajesContactoController/Edit/5
        public ActionResult Edit(int id)
        {
            mensajesContactoHelper = new MensajesContactoHelper();
            MensajesContactoViewModel mensajesContacto = mensajesContactoHelper.Get(id);
            ViewBag.idLocal = dropdownCreate();
            return View(mensajesContacto);
        }

        // POST: MensajesContactoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MensajesContactoViewModel mensajesContacto)
        {
            try
            {
                MensajesContactoHelper mensajesContactoHelper = new MensajesContactoHelper();
                mensajesContacto =mensajesContactoHelper.Edit(mensajesContacto);
               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MensajesContactoController/Delete/5
        public ActionResult Delete(int id)
        {
            mensajesContactoHelper = new MensajesContactoHelper();
            MensajesContactoViewModel mensajesContacto = mensajesContactoHelper.Get(id);

            return View(mensajesContacto);
        }

        // POST: MensajesContactoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MensajesContactoViewModel mensajesContacto)
        {
            try
            {
                mensajesContactoHelper = new MensajesContactoHelper();
                mensajesContactoHelper.Delete(mensajesContacto.IdMensaje);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
