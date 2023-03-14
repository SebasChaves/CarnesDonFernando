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
    public class RestauranteController : ControllerBase
    {
        private readonly ILogger<RestauranteController> logger;
        private IRestauranteDAL restauranteDAL;


        public RestauranteController(ILogger<RestauranteController> logger)
        {
            restauranteDAL = new RestauranteDALImpl(new proyectoCarnesDonFernandoContext());
            this.logger = logger;
        }

        private RestauranteModel? Convertir(Restaurante model)
        {
            if(model is null)
            {
                return null;
            }
            else
            {
                return new RestauranteModel
                {
                    IdRestaurante = model.IdRestaurante,
                    Horario = model.Horario,
                    NombreRestaurante = model.NombreRestaurante,
                    Ubicacion = model.Ubicacion,
                    UrlImg = model.UrlImg
                };
            }
        }
        private Restaurante? Convertir(RestauranteModel model)
        {
            if (model is null)
            {
                return null;
            }
            else
            {
                return new Restaurante
                {
                    IdRestaurante = model.IdRestaurante,
                    Horario = model.Horario,
                    NombreRestaurante = model.NombreRestaurante,
                    Ubicacion = model.Ubicacion,
                    UrlImg = model.UrlImg
                };
            }
        }

        // GET: api/<RestauranteController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Restaurante> restaurantes = restauranteDAL.GetAll();

            List<RestauranteModel> lista = new List<RestauranteModel>();

            foreach (var restaurante in restaurantes)
            {
                lista.Add(Convertir(restaurante)

                    );
            }
            return new JsonResult(lista);
        }

        // GET api/<RestauranteController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Restaurante restaurante;
            restaurante = restauranteDAL.Get(id);

            return new JsonResult(Convertir(restaurante));
        }

        // POST api/<RestauranteController>
        [HttpPost]
        public JsonResult Post([FromBody] RestauranteModel restaurante)
        {
            restauranteDAL.Add(Convertir(restaurante));
            return new JsonResult(restaurante);
        }

        // PUT api/<RestauranteController>/5
        [HttpPut]
        public JsonResult Put([FromBody] RestauranteModel restaurante)
        {
            restauranteDAL.Update(Convertir(restaurante));
            return new JsonResult(restaurante);
        }

        // DELETE api/<RestauranteController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Restaurante restaurante = new Restaurante { IdRestaurante = id };
            restauranteDAL.Remove(restaurante);

            return new JsonResult(Convertir(restaurante));
        }
    }
}
