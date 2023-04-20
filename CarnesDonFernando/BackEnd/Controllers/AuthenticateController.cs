using BackEnd.Models;
using Entities.Authentication;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("getUsuario")]
        public async Task<IActionResult> getUsuario([FromBody] LoginModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            var userId = userExists.Id;
            var userEmail = userExists.Email;
            return Ok(new
            {
                UserId = userId,
                UserCorreo = userEmail
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    role = userRoles[0]
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);

            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "El usuario ya existe" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Fallo la creación del usuario, revise las credenciales" });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.User))
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }

            string fromAddress = "proyectoprogramacionavanzada17@gmail.com";
            string toAddress = model.Email;
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
                "  <div class=\"container\">\r\n        <div class=\"header\">\r\n            <h1>Bienvenido a Carnes Don Fernando</h1>\r\n        </div>\r\n     " +
                "   <div class=\"content\">\r\n            <p>Hola " +model.Username+
                ",</p>\r\n            <p>Bienvenido a Carnes Don Fernando. Nos complace tenerte como miembro de nuestra comunidad.</p>\r\n    " +
                "                   <p>Si tienes alguna pregunta o necesitas ayuda, no dudes en contactarnos.</p>\r\n         " +
                "   <p>Saludos cordiales,</p>\r\n            <p>El equipo de Carnes Don Fernando</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n        " +
                "    <p>No responda a este correo electrónico. Si necesita ayuda, contacte con nuestro servicio de soporte.</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n";


            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("proyectoprogramacionavanzada17@gmail.com", "libesyyjduollcta");

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

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("putContrasenia")]
        public async Task<IActionResult> PutContrasenia([FromBody] ContraseniaModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.OldPassword))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var changePass = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);


                return Ok(new Response { Status = "Success", Message = "Cambio realizado correctamente!" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Fallo el cambio de contraseña, revise las credenciales" });
        }
    }
}
