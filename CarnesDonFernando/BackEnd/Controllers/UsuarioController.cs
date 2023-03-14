using DAL.Implementations;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> logger;
        private IUsuarioDAL usuarioDAL;


        public UsuarioController(ILogger<UsuarioController> logger)
        {
            usuarioDAL = new UsuarioDALImpl(new proyectoCarnesDonFernandoContext());
            this.logger = logger;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Usuario> usuarios = usuarioDAL.GetAll();


            return new JsonResult(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Usuario usuario;
            usuario = usuarioDAL.Get(id);

            return new JsonResult(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] Usuario usuario)
        {
            usuarioDAL.Add(usuario);
            return new JsonResult(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public JsonResult Put([FromBody] Usuario usuario)
        {
            usuarioDAL.Update(usuario);
            return new JsonResult(usuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Usuario usuario= new Usuario{ IdUsuario= id };
            usuarioDAL.Remove(usuario);

            return new JsonResult(usuario);
        }
    }
}
