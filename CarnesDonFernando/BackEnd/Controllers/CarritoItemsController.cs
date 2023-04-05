using DAL.Interfaces;
using DAL.Implementations;
using Entities;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoItemsController : ControllerBase
    {
        private readonly ILogger<CarritoItemsController> logger;
        private ICarritoItemDAL carritoDAL;

        private static readonly HttpClient client = new HttpClient();

        public CarritoItemsController(ILogger<CarritoItemsController> logger)
        {
            carritoDAL = new CarritoItemDALImpl(new pruebasCarnesDonFernandoContext());
            this.logger = logger;
        }

        private CarritoItemModel? Convertir(CarritoItem model)
        {
            if (model is null)
            {
                return null;
            }
            else
            {
                return new CarritoItemModel
                {
                    IdCarritoItems = model.IdCarritoItems,
                    IdCarrito= model.IdCarrito,
                    Cantidad=model.Cantidad,
                    IdProducto=model.IdProducto,    
                    Precio=model.Precio
                };
            }
        }
        private CarritoItem? Convertir(CarritoItemModel model)
        {
            if (model is null)
            {
                return null;
            }
            else
            {
                return new CarritoItem
                {
                    IdCarritoItems = model.IdCarritoItems,
                    IdCarrito = model.IdCarrito,
                    Cantidad = model.Cantidad,
                    IdProducto = model.IdProducto,
                    Precio = model.Precio
                };
            }
        }

        // GET: api/<CarritoController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<CarritoItem> carritos= carritoDAL.GetAll();

            List<CarritoItemModel> lista = new List<CarritoItemModel>();

            foreach (var local in carritos)
            {
                lista.Add(Convertir(local)

                    );
            }
            return new JsonResult(lista);
        }

        // GET api/<CarritoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            CarritoItem carrito;
            carrito = carritoDAL.Get(id);

            return new JsonResult(Convertir(carrito));
        }

        [HttpGet("GetCarritoUsuario/{id}")]
        public JsonResult GetCarritoUsuario(int id)
        {
            IEnumerable<CarritoItem> carritos = carritoDAL.GetAll();
            List<CarritoItemModel> lista = new List<CarritoItemModel>();

            foreach (var producto in carritos)
            {
                if (producto.IdCarrito == id)
                {
                    lista.Add(Convertir(producto));
                }
            }

            return new JsonResult(lista);
        }

        private void actualizaPrecio(int idCarrito, decimal precioFinal)
        {
            string apiUrl = "http://localhost:5180/api/Carrito/" + idCarrito;
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Carrito carritoGet = JsonConvert.DeserializeObject<Carrito>(content);

            Carrito carritoApi = new Carrito { IdCarrito = carritoGet.IdCarrito, FechaCreado = carritoGet.FechaCreado, IdUsuario = carritoGet.IdUsuario, PrecioFinal = precioFinal };
            HttpClient ClientPut = new HttpClient();
            ClientPut.BaseAddress = new Uri("http://localhost:5180");
            HttpResponseMessage responseMessage = ClientPut.PutAsJsonAsync("api/Carrito/", carritoApi).Result;
        }

        // POST api/<CarritoController>
        [HttpPost]
        public JsonResult Post([FromBody] CarritoItemModel carrito)
        {
            
            CarritoItem carritoItem;
            using (UnidadDeTrabajo<CarritoItem> unidad = new UnidadDeTrabajo<CarritoItem>(new pruebasCarnesDonFernandoContext()))
            {
                decimal precioFinal = carrito.Precio;

                IEnumerable<CarritoItem> carritos = carritoDAL.GetAll();
                List<CarritoItemModel> lista = new List<CarritoItemModel>();

                foreach (var producto in carritos)
                {
                    if (producto.IdCarrito == carrito.IdCarrito)
                    {
                        precioFinal = precioFinal + producto.Precio;
                    }
                }

                string apiUrl = "http://localhost:5180/api/Carrito/" + carrito.IdCarrito.ToString();
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Carrito carritoGet = JsonConvert.DeserializeObject<Carrito>(content);

                Carrito carritoApi = new Carrito { IdCarrito = carritoGet.IdCarrito, FechaCreado = carritoGet.FechaCreado, IdUsuario = carritoGet.IdUsuario, PrecioFinal = precioFinal };
                HttpClient ClientPut = new HttpClient();
                ClientPut.BaseAddress = new Uri("http://localhost:5180");
                HttpResponseMessage responseMessage = ClientPut.PutAsJsonAsync("api/Carrito/", carritoApi).Result;


                unidad.genericDAL.Add(Convertir(carrito));                
                unidad.Complete();
            }
            //carritoDAL.Add(Convertir(carrito));
            return new JsonResult(carrito);
        }

        // PUT api/<CarritoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CarritoItemModel carrito)
        {


            /*
             * Agregar codigo
             * Que actualiza el precio final en la tabla carrito
             */

            carritoDAL.Update(Convertir(carrito));
            return new JsonResult(carrito);
        }

        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            //decimal precioFinal;

            /*string apiUrl = "http://localhost:5180/api/Carrito/" + id.ToString();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Carrito carritoGet = JsonConvert.DeserializeObject<Carrito>(content);

           // precioFinal = carritoGet.PrecioFinal;

            Carrito carritoApi = new Carrito { IdCarrito = carritoGet.IdCarrito, FechaCreado = carritoGet.FechaCreado, IdUsuario = carritoGet.IdUsuario, PrecioFinal = precioFinal };
            HttpClient ClientPut = new HttpClient();
            ClientPut.BaseAddress = new Uri("http://localhost:5180");
            HttpResponseMessage responseMessage = ClientPut.PutAsJsonAsync("api/Carrito/", carritoApi).Result;


            CarritoItem carrito= new CarritoItem { IdCarritoItems= id };
            carritoDAL.Remove(carrito);            */


            CarritoItem carritoItem;
            decimal precioFinal;
            using (UnidadDeTrabajo<CarritoItem> unidad = new UnidadDeTrabajo<CarritoItem>(new pruebasCarnesDonFernandoContext()))
            {
                CarritoItem itemTraido = unidad.genericDAL.Get(id);

                string apiUrl = "http://localhost:5180/api/Carrito/" + itemTraido.IdCarrito.ToString();
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Carrito carritoGet = JsonConvert.DeserializeObject<Carrito>(content);

                precioFinal = carritoGet.PrecioFinal - itemTraido.Precio;

                Carrito carritoApi = new Carrito { IdCarrito = carritoGet.IdCarrito, FechaCreado = carritoGet.FechaCreado, IdUsuario = carritoGet.IdUsuario, PrecioFinal = precioFinal };
                HttpClient ClientPut = new HttpClient();
                ClientPut.BaseAddress = new Uri("http://localhost:5180");
                HttpResponseMessage responseMessage = ClientPut.PutAsJsonAsync("api/Carrito/", carritoApi).Result;

                /*CarritoItem carritoQuitar = new CarritoItem { IdCarritoItems = id };
                unidad.genericDAL.Remove(carritoQuitar);
                unidad.Complete();
                return new JsonResult(Convertir(carritoQuitar));*/
            }
            CarritoItem carritoItem1 = new CarritoItem { IdCarritoItems = id };
            carritoDAL.Remove(carritoItem1);
            return new JsonResult(Convertir(carritoItem1));
            
        }

        [HttpDelete]
        public JsonResult DeleteRange()
        {        
            carritoDAL.RemoveRange(carritoDAL.GetAll());

            return new JsonResult(Get());
        }

        [HttpDelete("DeleteCarrito/{id}")]
        public JsonResult DeleteCarrito(int id)
        {
            // IEnumerable<CarritoItem> carritos = JsonConvert.DeserializeObject<List<Producto>>(contenidoJson) GetCarritoUsuario(id);
            JsonResult resultado = GetCarritoUsuario(id);
            string contenidoJson = JsonConvert.SerializeObject(resultado.Value);
            List<CarritoItem> lista = JsonConvert.DeserializeObject<List<CarritoItem>>(contenidoJson);
            
            

           /* CarritoItem carrito = new CarritoItem { IdCarritoItems = id };
            carritoDAL.Remove(carrito);*/
            /*foreach (var producto in carritos)
            {
                if (producto.IdCarrito == id)
                {                   
                    lista.Add(producto);
                }
            }
            bool flag = true;*/
            foreach (var producto in lista)
            {
                CarritoItem carrito = new CarritoItem { IdCarritoItems = producto.IdCarrito };
                carritoDAL.Remove(carrito);
            }

            // return new JsonResult(GetCarritoUsuario(id));
            return new JsonResult("HOLA");
        }
    }
}
