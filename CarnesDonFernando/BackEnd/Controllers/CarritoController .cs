using DAL.Interfaces;
using DAL.Implementations;
using Entities;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ILogger<CarritoController> logger;
        private ICarritoDAL carritoDAL;

        public CarritoController(ILogger<CarritoController> logger)
        {
            carritoDAL = new CarritoDALImpl(new pruebasCarnesDonFernandoContext());
            this.logger = logger;
        }

        private CarritoModel? Convertir(Carrito model)
        {
            if (model is null)
            {
                return null;
            }
            else
            {
                return new CarritoModel
                {
                    IdCarrito = model.IdCarrito,
                    FechaCreado = model.FechaCreado,
                   IdUsuario = model.IdUsuario,
                   PrecioFinal = model.PrecioFinal
                };
            }
        }
        private Carrito? Convertir(CarritoModel model)
        {
            if (model is null)
            {
                return null;
            }
            else
            {
                return new Carrito
                {
                    IdCarrito = model.IdCarrito,
                    FechaCreado = model.FechaCreado,
                    IdUsuario = model.IdUsuario,
                    PrecioFinal = model.PrecioFinal
                };
            }
        }

        // GET: api/<CarritoController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Carrito> carritos= carritoDAL.GetAll();

            List<CarritoModel> lista = new List<CarritoModel>();

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
            Carrito carrito;
            carrito = carritoDAL.Get(id);

            return new JsonResult(Convertir(carrito));
        }

        [HttpGet("GetCarritoUsuario/{id}")]
        public JsonResult GetCarritoUsuario(int id)
        {
            IEnumerable<Carrito> carritos = carritoDAL.GetAll();
            CarritoModel carrito = new CarritoModel();

            foreach (var producto in carritos)
            {
                if (producto.IdUsuario == id)
                {
                    carrito = Convertir(producto);
                }
            }

            return new JsonResult(carrito);
        }

        // POST api/<CarritoController>
        [HttpPost]
        public JsonResult Post([FromBody] CarritoModel carrito)
        {
            carritoDAL.Add(Convertir(carrito));
            return new JsonResult(carrito);
        }

        [HttpPut("PutPrecio")]
        public JsonResult Put(decimal precio, int id)
        {
            Carrito carrito;
            using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(new pruebasCarnesDonFernandoContext()))
            {
                carrito = unidad.genericDAL.Get(id);
                carrito.PrecioFinal = precio;
                unidad.genericDAL.Update(carrito);
                unidad.Complete();
            }


            //Carrito carrito = carritoDAL.Get(id);
            /*carrito.PrecioFinal = precio;
            carritoDAL.Update(carrito);*/
            return new JsonResult(carrito);
        }

        // PUT api/<CarritoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CarritoModel carrito)
        {
            carritoDAL.Update(Convertir(carrito));
            return new JsonResult(carrito);
        }

        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Carrito carrito= new Carrito{ IdCarrito= id };
            carritoDAL.Remove(carrito);

            return new JsonResult(Convertir(carrito));
        }
    }
}
