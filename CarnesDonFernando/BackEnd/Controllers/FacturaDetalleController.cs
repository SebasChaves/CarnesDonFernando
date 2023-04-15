using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaDetalleController : ControllerBase
    {
        private readonly ILogger<FacturaDetalleController> logger;
        private IFacturaDetalleDAL recetaDAL;

        public FacturaDetalleController(ILogger<FacturaDetalleController> logger)
        {
            recetaDAL = new FacturaDetalleDALImpl(new pruebasCarnesDonFernandoContext());
            this.logger = logger;
        }

        private FacturaDetalleModel? Convertir(FacturaDetalle model)
        {
            return new FacturaDetalleModel
            {
                IdFactura = model.IdFactura,
                Cantidad    = model.Cantidad,
                IdFacturaDetalle = model.IdFacturaDetalle,
                IdProducto = model.IdProducto,
                Precio = model.Precio
            };


        }
        private FacturaDetalle? Convertir(FacturaDetalleModel model)
        {
            return new FacturaDetalle
            {
                IdFactura = model.IdFactura,
                Cantidad = model.Cantidad,
                IdFacturaDetalle = model.IdFacturaDetalle,
                IdProducto = model.IdProducto,
                Precio = model.Precio
            };
        }
        // GET: api/<RecetaController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<FacturaDetalle> recetas = recetaDAL.GetAll();

            List<FacturaDetalleModel> lista = new List<FacturaDetalleModel>();

            foreach (var receta in recetas)
            {
                lista.Add(Convertir(receta)

                    );
            }
            return new JsonResult(lista);
        }

        // GET api/<RecetaController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            FacturaDetalle receta;
            receta = recetaDAL.Get(id);

            return new JsonResult(Convertir(receta));
        }

        // POST api/<RecetaController>
        [HttpPost]
        public JsonResult Post([FromBody] FacturaDetalleModel receta)
        {
            recetaDAL.Add(Convertir(receta));
            return new JsonResult(receta);
        }
            


        // PUT api/<RecetaController>/5
        [HttpPut]
        public JsonResult Put([FromBody] FacturaDetalleModel receta)
        {
            recetaDAL.Update(Convertir(receta));
            return new JsonResult(receta);
        }

        // DELETE api/<RecetaController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            FacturaDetalle receta = new FacturaDetalle { IdFacturaDetalle = id };
            recetaDAL.Remove(receta);

            return new JsonResult(Convertir(receta));
        }
    }
}
