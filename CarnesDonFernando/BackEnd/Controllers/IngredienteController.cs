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
    public class IngredienteController : ControllerBase
    {
        private IIngredienteDAL ingredienteDAL;
        private readonly ILogger<IngredienteController> logger;

        public IngredienteController(ILogger<IngredienteController> logger)
        {
            ingredienteDAL = new IngredienteDALImpl(new proyectoCarnesDonFernandoContext());
            this.logger = logger;
        }

        private IngredienteModel? Convertir(Ingrediente model)
        {
            return new IngredienteModel
            {
                IdIngrediente = model.IdIngrediente,
                Descripcion= model.Descripcion
            };


        }
        private Ingrediente? Convertir(IngredienteModel model)
        {
            return new Ingrediente
            {
                IdIngrediente = model.IdIngrediente,
                Descripcion = model.Descripcion
            };
        }

        // GET: api/<IngredienteController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Ingrediente> ingredientes = ingredienteDAL.GetAll();

            List<IngredienteModel> lista = new List<IngredienteModel>();

            foreach (var ingrediente in ingredientes)
            {
                lista.Add(Convertir(ingrediente)

                    );
            }
            return new JsonResult(lista);
        }

        // GET api/<IngredienteController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Ingrediente ingrediente;
            ingrediente = ingredienteDAL.Get(id);

            return new JsonResult(Convertir(ingrediente));
        }

        // POST api/<IngredienteController>
        [HttpPost]
        public JsonResult Post([FromBody] IngredienteModel ingrediente)
        {
            ingredienteDAL.Add(Convertir(ingrediente));
            return new JsonResult(ingrediente);
        }



        // PUT api/<IngredienteController>/5
        [HttpPut]
        public JsonResult Put([FromBody] IngredienteModel ingrediente)
        {
            ingredienteDAL.Update(Convertir(ingrediente));
            return new JsonResult(ingrediente);
        }

        // DELETE api/<Ingredienteontroller>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Ingrediente ingrediente = new Ingrediente { IdIngrediente = id };
            ingredienteDAL.Remove(ingrediente);

            return new JsonResult(Convertir(ingrediente));
        }
    }
}
