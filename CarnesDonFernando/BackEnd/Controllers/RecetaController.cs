using DAL.Implementations;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities;
using BackEnd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaController : ControllerBase
    {
        private readonly ILogger<RecetaController> logger;
        private IRecetaDAL recetaDAL;

        public RecetaController(ILogger<RecetaController> logger)
        {
            recetaDAL = new RecetaDALImpl(new proyectoCarnesDonFernandoContext());
            this.logger = logger;
        }

        private RecetaModel? Convertir(Receta model)
        {
            return new RecetaModel
            {
                IdReceta= model.IdReceta,
                IdIngrediente=model.IdIngrediente,
                DescripcionReceta=model.DescripcionReceta,
                NombreReceta =model.NombreReceta
            };


        }
        private Receta? Convertir(RecetaModel model)
        {
            return new Receta
            {
                IdReceta = model.IdReceta,
                IdIngrediente = model.IdIngrediente,
                DescripcionReceta = model.DescripcionReceta,
                NombreReceta = model.NombreReceta
            };
        }

        // GET: api/<RecetaController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Receta> recetas = recetaDAL.GetAll();

            List<RecetaModel> lista = new List<RecetaModel>();

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
            Receta receta;
            receta = recetaDAL.Get(id);

            return new JsonResult(Convertir(receta));
        }

        // POST api/<RecetaController>
        [HttpPost]
        public JsonResult Post([FromBody] RecetaModel receta)
        {
            recetaDAL.Add(Convertir(receta));
            return new JsonResult(receta);
        }



        // PUT api/<RecetaController>/5
        [HttpPut]
        public JsonResult Put([FromBody] RecetaModel receta)
        {
            recetaDAL.Update(Convertir(receta));
            return new JsonResult(receta);
        }

        // DELETE api/<RecetaController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Receta receta = new Receta { IdReceta = id };
            recetaDAL.Remove(receta);

            return new JsonResult(Convertir(receta));
        }
    }
}