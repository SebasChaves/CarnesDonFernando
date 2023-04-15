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
    public class FacturaController : ControllerBase
    {
        private readonly ILogger<FacturaController> logger;
        private IFacturaDAL recetaDAL;

        public FacturaController(ILogger<FacturaController> logger)
        {
            recetaDAL = new FacturaDALImpl(new pruebasCarnesDonFernandoContext());
            this.logger = logger;
        }

        private FacturaModel? Convertir(Factura model)
        {
            return new FacturaModel
            {
                IdFactura = model.IdFactura,                
                FechaCreado = model.FechaCreado,
                EstadoFactura = model.EstadoFactura,
                PrecioFinal = model.PrecioFinal,
                ApellidoUsuario = model.ApellidoUsuario,
                CedulaUsuario = model.CedulaUsuario,
                CorreoUsuario = model.CorreoUsuario,
                DireccionUsuario = model.DireccionUsuario,
                NombreUsuario = model.NombreUsuario,
                TelefonoUsuario = model.TelefonoUsuario,
                IdUsuario = model.IdUsuario
            };


        }
        private Factura? Convertir(FacturaModel model)
        {
            return new Factura
            {
                IdFactura = model.IdFactura,
                FechaCreado = model.FechaCreado,
                EstadoFactura = model.EstadoFactura,
                PrecioFinal = model.PrecioFinal,
                ApellidoUsuario = model.ApellidoUsuario,
                CedulaUsuario = model.CedulaUsuario,
                CorreoUsuario = model.CorreoUsuario,
                DireccionUsuario = model.DireccionUsuario,
                NombreUsuario = model.NombreUsuario,
                TelefonoUsuario = model.TelefonoUsuario,
                IdUsuario = model.IdUsuario
            };
        }
        // GET: api/<RecetaController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Factura> recetas = recetaDAL.GetAll();

            List<FacturaModel> lista = new List<FacturaModel>();

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
            Factura receta;
            receta = recetaDAL.Get(id);

            return new JsonResult(Convertir(receta));
        }

        // POST api/<RecetaController>
        [HttpPost]
        public JsonResult Post([FromBody] FacturaModel receta)
        {
            recetaDAL.Add(Convertir(receta));
            return new JsonResult(receta);
        }
            


        // PUT api/<RecetaController>/5
        [HttpPut]
        public JsonResult Put([FromBody] FacturaModel receta)
        {
            recetaDAL.Update(Convertir(receta));
            return new JsonResult(receta);
        }

        // DELETE api/<RecetaController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Factura receta = new Factura { IdFactura = id };
            recetaDAL.Remove(receta);

            return new JsonResult(Convertir(receta));
        }
    }
}
