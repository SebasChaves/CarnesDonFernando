using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FrontEnd.Controllers
{
    public class ContactoController : Controller
    {
        MensajesContactoHelper mensajesContactoHelper = new MensajesContactoHelper();
        LocalHelper localHelper = new LocalHelper();

        private readonly ILogger<ContactoController> _logger;

        public ContactoController(ILogger<ContactoController> logger)
        {
            _logger = logger;
        }

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

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") is not null)
            {
                if (HttpContext.Session.GetString("role").Equals("Admin"))
                {
                    mensajesContactoHelper = new MensajesContactoHelper(HttpContext.Session.GetString("token"));
                    List<MensajesContactoViewModel> lista = mensajesContactoHelper.GetAll();
                    //ViewBag.isConfirm = false;
                    return View(lista);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            ViewBag.idLocal = dropdownCreate();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MensajesContactoViewModel mensajesContacto)
        {
            try
            {
                mensajesContactoHelper = new MensajesContactoHelper();
                mensajesContacto = mensajesContactoHelper.Create(mensajesContacto);
                ViewBag.isConfirm = true;
                Thread.Sleep(5000);

                return RedirectToAction("Create","Contacto");
                //return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int idMensaje)
        {
            try
            {
                 if (HttpContext.Session.GetString("role") is not null)
                 {
                     if (HttpContext.Session.GetString("role").Equals("Admin"))
                     {
                        mensajesContactoHelper = new MensajesContactoHelper(HttpContext.Session.GetString("token"));
                        mensajesContactoHelper.Delete(idMensaje);                        
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

