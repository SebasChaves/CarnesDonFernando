using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CarritoController : Controller
    {
        

        ProductoHelper productoHelper = new ProductoHelper();
        UsuarioHelper usuarioHelper = new UsuarioHelper();
        CarritoHelper carritoHelper = new CarritoHelper();
        //CarritoHelper carritoHelper;
        CarritoItemsHelper carritoItemsHelper = new CarritoItemsHelper();
        //CarritoItemsHelper carritoItemsHelper;

        int idCarritoUsuario = 0;
        //string idUsuarioSession = "Prueba";




        // GET: CarritoController
        public ActionResult Index(string idUsuario)
        {
            /*if (HttpContext.Session.GetString("userId") is not null)
            {
                this.idUsuarioSession = HttpContext.Session.GetString("userId");
            }*/
            if(idUsuario is null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                if (HttpContext.Session.GetString("userId") is not null)
                {
                    /*carritoHelper = new CarritoHelper(HttpContext.Session.GetString("token"));
                    carritoItemsHelper = new CarritoItemsHelper(HttpContext.Session.GetString("token"));

                    string us = HttpContext.Session.GetString("userId");
                    string tok = HttpContext.Session.GetString("token");*/


                    idCarritoUsuario = carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito;

                    carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito);
                    List<CarritoItemViewModel> lista = carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito);
                    List<ProductoViewModel> productos = new List<ProductoViewModel>();
                    CarritoViewModel carritoCompuesto = carritoHelper.SetUsuario(HttpContext.Session.GetString("userId"));

                    foreach (var producto in lista)
                    {
                        productos.Add(productoHelper.Get(producto.IdProducto));
                    }



                    var viewModel = new ProductoCarritoViewModelCompuesto { Productos = productos, CarritoItems = lista, Carrito = carritoCompuesto };

                    return View(viewModel);
                }
                return View();
            }
            
        }
        public ActionResult verCarritos()
        {
            if (HttpContext.Session.GetString("role") is not null)
            {
                if (HttpContext.Session.GetString("role").Equals("Admin"))
                {
                    carritoHelper = new CarritoHelper(HttpContext.Session.GetString("token"));
                    List<CarritoViewModel> lista = carritoHelper.GetAll();
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
        public ActionResult verCarritosItems()
        {
            if (HttpContext.Session.GetString("role") is not null)
            {
                if (HttpContext.Session.GetString("role").Equals("Admin"))
                {
                    carritoItemsHelper = new CarritoItemsHelper(HttpContext.Session.GetString("token"));
                    List<CarritoItemViewModel> lista = carritoItemsHelper.GetAll();
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
        // GET: CarritoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarritoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarritoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarritoController/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: CarritoController/Delete/5
       
        public ActionResult Delete(int id)
        {
            try
            {
                //carritoItemsHelper = new CarritoItemsHelper(HttpContext.Session.GetString("token"));
                carritoItemsHelper.Delete(id);
                return RedirectToAction(nameof(Index), new { idUsuario = HttpContext.Session.GetString("userId") });
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult DeleteAll()
        {
            try
            {
                if(HttpContext.Session.GetString("userId") is not null)
                {
                    /*carritoHelper = new CarritoHelper(HttpContext.Session.GetString("token"));
                    carritoItemsHelper = new CarritoItemsHelper(HttpContext.Session.GetString("token"));*/

                    List<CarritoItemViewModel> lista = carritoItemsHelper.GetCarrito(carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito);

                    foreach (var item in lista)
                    {
                        carritoItemsHelper.Delete(item.IdCarritoItems);
                    }

                    //carritoItemsHelper.Delete(3);

                    return RedirectToAction(nameof(Index), new { idUsuario = HttpContext.Session.GetString("userId") });
                } return View();
                
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AgregarCarrito(int idProducto, int cantidadProducto)
        {
            /*if (HttpContext.Session.GetString("idUsuario") is null)
            {
                //this.idCarritoUsuario = carritoHelper.SetUsuario(1).IdCarrito;
            }*/
            if(HttpContext.Session.GetString("userId") is not null)
            {
                /*carritoHelper = new CarritoHelper(HttpContext.Session.GetString("token"));
                carritoItemsHelper = new CarritoItemsHelper(HttpContext.Session.GetString("token"));*/

                this.idCarritoUsuario = carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito;

                int precioFinal = productoHelper.Get(idProducto).Precio * cantidadProducto;
                CarritoItemViewModel model = new CarritoItemViewModel
                {
                    IdCarrito = this.idCarritoUsuario,
                    IdProducto = idProducto,
                    Cantidad = cantidadProducto,
                    Precio = precioFinal,
                    idUsuario = HttpContext.Session.GetString("userId")
                };

                carritoItemsHelper.Create(model);


                return RedirectToAction(nameof(Index), new { idUsuario = HttpContext.Session.GetString("userId") });
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost]
        public ActionResult ActualizaCarrito(int[] idProducto, int[] cantidadProducto, int[] idCarritoItem)
        {

            /*carritoHelper = new CarritoHelper(HttpContext.Session.GetString("token"));
            carritoItemsHelper = new CarritoItemsHelper(HttpContext.Session.GetString("token"));*/

            // this.idCarritoUsuario = carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito;

            for (int i = 0; i < idProducto.Length; i++)
            {
                int precioFinal = productoHelper.Get(idProducto[i]).Precio * cantidadProducto[i];
                CarritoItemViewModel model = new CarritoItemViewModel
                {
                    IdCarrito = carritoHelper.SetUsuario(HttpContext.Session.GetString("userId")).IdCarrito,
                    IdProducto = idProducto[i],
                    Cantidad = cantidadProducto[i],
                    Precio = precioFinal,
                    IdCarritoItems = idCarritoItem[i],
                    idUsuario = ""
                };

                carritoItemsHelper.Edit(model);
            }
            return RedirectToAction(nameof(Index), new { idUsuario = HttpContext.Session.GetString("userId") });
        }
    }
}
