using DAL.Interfaces;
using DAL.Implementations;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> logger;
        private ICategoriaDAL categoriaDAL;

        public CategoriaController(ILogger<CategoriaController> logger)
        {
            categoriaDAL = new CategoriaDALImpl(new proyectoCarnesDonFernandoContext());
            this.logger = logger;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Categoria> categorias = categoriaDAL.GetAll();


            return new JsonResult(categorias);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Categoria category;
            category = categoriaDAL.Get(id);

            return new JsonResult(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] Categoria categoria)
        {
            categoriaDAL.Add(categoria);
            return new JsonResult(categoria);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] Categoria category)
        {
            categoriaDAL.Update(category);
            return new JsonResult(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Categoria category = new Categoria { IdCategoria = id };
            categoriaDAL.Remove(category);

            return new JsonResult(category);
        }
    }
}
