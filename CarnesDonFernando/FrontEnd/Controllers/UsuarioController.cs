using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioHelper usuarioHelper = new UsuarioHelper();

        // GET: ProductoController
        public ActionResult Index()
        {
                       
            List<UsuarioViewModel> lista = usuarioHelper.GetAll();

            return View(lista);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {

            UsuarioViewModel usuario = usuarioHelper.Get(id);

            return View(usuario);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                
                usuario = usuarioHelper.Create(usuario);

                return RedirectToAction("Details", new { id = usuario.IdUsuario});
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            
            UsuarioViewModel usuario = usuarioHelper.Get(id);

            return View(usuario);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            try
            {
               
                usuario = usuarioHelper.Edit(usuario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioViewModel usuario = usuarioHelper.Get(id);

            return View(usuario);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                usuarioHelper.Delete(usuario.IdUsuario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
