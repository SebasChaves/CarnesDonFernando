using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net.Mail;
using System.Net;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioHelper usuarioHelper = new UsuarioHelper();
        SecurityHelper securityHelper = new SecurityHelper();

        // GET: ProductoController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("token") is not null)
            {
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            } 
            
           
        }

        [HttpPost]
        public IActionResult Index(LoginModel usuario)
        {
            return View();
        }

        public ActionResult Login() { 
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel usuario)
        {

            TokenModel tokenModel = securityHelper.Login(usuario);


            if (tokenModel.Token is not null)
            {
                IdUsuario idUsuario1 = securityHelper.getIdUsuario(usuario);
                HttpContext.Session.SetString("token", tokenModel.Token);
                HttpContext.Session.SetString("userId", idUsuario1.UserId);
                HttpContext.Session.SetString("userCorreo", idUsuario1.UserCorreo);

                HttpContext.Session.SetString("nombreUsuario", usuario.Username);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Message = "Error al iniciar sesión";
            }
            var token = HttpContext.Session.GetString("token");
            var idUsuario = HttpContext.Session.GetString("userId");
            

            return View();
        }
        public ActionResult LogOff()
        {
            if (HttpContext.Session.GetString("token") is not null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction(nameof(Login));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }

        
        }
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(RegisterModel usuario)
        {
            ResponseModel response = securityHelper.Registrar(usuario);
            if (response.Status.Equals("Success"))
            {
                LoginModel login = new LoginModel {
                Username= usuario.Username,
                Password= usuario.Password
                };
                Login(login);
                return RedirectToAction(nameof(Index));
            }else if (response.Status.Equals("Error"))
            {
                ViewBag.Message = response.Message.ToString();
            }

            var token = HttpContext.Session.GetString("token");
            var idUsuario = HttpContext.Session.GetString("userId");
            return View();
        }

        public ActionResult CambioContrasenia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CambioContrasenia(ContraseniaModel usuario)
        {
            var nombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            usuario.Username = nombreUsuario;
            ResponseModel response = securityHelper.CambioContrasenia(usuario);
            if (response.Status.Equals("Success"))
            {
                LoginModel login = new LoginModel
                {
                    Username = usuario.Username,
                    Password = usuario.NewPassword
                };
                Login(login);
                return RedirectToAction("LogOff");
            }
            else if (response.Status.Equals("Error"))
            {
                ViewBag.Message = response.Message.ToString();
            }

            var token = HttpContext.Session.GetString("token");
            var idUsuario = HttpContext.Session.GetString("userId");
            return View();
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
