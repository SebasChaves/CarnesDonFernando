using DAL.Interfaces;
using DAL.Implementations;
using Entities;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoItemsController : ControllerBase
    {
        private readonly ILogger<CarritoItemsController> logger;
        private ICarritoItemDAL carritoDAL;

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

        // POST api/<CarritoController>
        [HttpPost]
        public JsonResult Post([FromBody] CarritoItemModel carrito)
        {
            carritoDAL.Add(Convertir(carrito));
            return new JsonResult(carrito);
        }

        // PUT api/<CarritoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CarritoItemModel carrito)
        {
            carritoDAL.Update(Convertir(carrito));
            return new JsonResult(carrito);
        }

        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            CarritoItem carrito= new CarritoItem { IdCarritoItems= id };
            carritoDAL.Remove(carrito);

            return new JsonResult(Convertir(carrito));
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
