using DAL.Interfaces;
using DAL.Implementations;
using Microsoft.AspNetCore.Mvc;
using Entities;
using BackEnd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class MensajesContactoController : ControllerBase
    {

        private IDALMensajesContacto DALMensajesContacto;
        private readonly ILogger<MensajesContactoController> logger;

        public MensajesContactoController(ILogger<MensajesContactoController> logger)
        {
            DALMensajesContacto = new MensajesContactoDALImpl(new Entities.proyectoCarnesDonFernandoContext());
            this.logger= logger;
        }

        private MensajesContactoModel? Convertir(MensajesContacto model)
        {
            return new MensajesContactoModel
            {
               IdMensaje = model.IdMensaje,
               IdLocal = model.IdLocal,
               Correo = model.Correo,
               Mensaje= model.Mensaje,
               NombrePersona= model.NombrePersona,
               Telefono = model.Telefono
            };


        }
        private MensajesContacto? Convertir(MensajesContactoModel model)
        {
            return new MensajesContacto
            {
                IdMensaje = model.IdMensaje,
                IdLocal = model.IdLocal,
                Correo = model.Correo,
                Mensaje = model.Mensaje,
                NombrePersona = model.NombrePersona,
                Telefono = model.Telefono
            };
        }

        // GET: api/<MensajesContactoController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<MensajesContacto> mensajes = DALMensajesContacto.GetAll();

            List<MensajesContactoModel> lista = new List<MensajesContactoModel>();

            foreach (var mensaje in mensajes)
            {
                lista.Add(Convertir(mensaje)

                    );
            }
            return new JsonResult(lista);
        }

        // GET api/<MensajesContactoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            MensajesContacto mensajesContacto;
            mensajesContacto = DALMensajesContacto.Get(id);

            return new JsonResult(Convertir(mensajesContacto));
        }

        // POST api/<MensajesContactoController>
        [HttpPost]
        public JsonResult Post([FromBody] MensajesContactoModel mensajesContacto)
        {
            DALMensajesContacto.Add(Convertir(mensajesContacto));
            return new JsonResult(mensajesContacto);
        }


        // PUT api/<MensajesContactoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] MensajesContactoModel mensajesContacto)
        {
            DALMensajesContacto.Update(Convertir(mensajesContacto));
            return new JsonResult(mensajesContacto);
        }

        // DELETE api/<MensajesContactoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MensajesContacto mensajes = new MensajesContacto { IdMensaje = id };
            DALMensajesContacto.Remove(mensajes);

            return new JsonResult(Convertir(mensajes));
        }
    }
}
