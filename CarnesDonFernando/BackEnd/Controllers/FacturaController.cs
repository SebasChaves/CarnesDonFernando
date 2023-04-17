using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

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
            string fromAddress = "freddiemercury1705@gmail.com";
            string toAddress = receta.CorreoUsuario;
            string subject = "Creacion de cuenta en Carnes Don Fernando";
            //string body = "<h3 style: color='#000000 '>Se ha creado una cuenta en la pagina de Carnes Don Fernando, con el siguiente nombre de usuario: </h3><h3 style: color='#AD2022'>" + model.Username+"</h3>";
            string body = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    " +
                "<meta charset=\"UTF-8\">\r\n    <title>Bienvenido a Carnes Don Fernando</title>\r\n   " +
                " <style>\r\n        /* Estilos de la plantilla */\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n           " +
                " font-size: 16px;\r\n            color: #333;\r\n            line-height: 1.6;\r\n            background-color: #f7f7f7;\r\n            " +
                "padding: 0;\r\n            margin: 0;\r\n        }\r\n\r\n        .container {\r\n            max-width: 600px;\r\n            " +
                "margin: 0 auto;\r\n        }\r\n\r\n        .header {\r\n            background-color: #eee;\r\n            padding: 20px;\r\n         " +
                "   text-align: center;\r\n        }\r\n\r\n        .header h1 {\r\n            margin: 0;\r\n        }\r\n\r\n        .content {\r\n     " +
                "       background-color: #fff;\r\n            padding: 20px;\r\n        }\r\n\r\n        .footer {\r\n            background-color: #eee;\r\n  " +
                "          padding: 20px;\r\n            text-align: center;\r\n            font-size: 14px;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n  " +
                "  <div class=\"container\">\r\n        <div class=\"header\">\r\n            <h1>Notificacion de compra en Carnes Don Fernando</h1>\r\n        </div>\r\n     " +
                "   <div class=\"content\">\r\n            <p>Hola " + receta.NombreUsuario + " " + receta.ApellidoUsuario+ 
                ",</p>\r\n            <p>Le informamos que ha hecho un encargo por un total de " + receta.PrecioFinal +
                " colones</p>\r\n    " +
                "        <p>El pago se hara cuando reciba los productos adquiridos</p>\r\n           " +
                "   <p>Si tienes alguna pregunta o necesitas ayuda, no dudes en contactarnos.</p>\r\n         " +
                "   <p>Saludos cordiales,</p>\r\n            <p>El equipo de Carnes Don Fernando</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n        " +
                "    <p>No responda a este correo electrónico. Si necesita ayuda, contacte con nuestro servicio de soporte.</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n";


            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("freddiemercury1705@gmail.com", "dhxpwyxyugncbezo");

            MailMessage message = new MailMessage(fromAddress, toAddress, subject, body);
            message.IsBodyHtml = true;
            message.IsBodyHtml = true;

            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
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
