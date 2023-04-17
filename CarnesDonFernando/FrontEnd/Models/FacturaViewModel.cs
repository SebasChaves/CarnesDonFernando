//using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FrontEnd.Models
{
    public  class FacturaViewModel
    {

        public int IdFactura { get; set; }
        public DateTime FechaCreado { get; set; }
        public string IdUsuario { get; set; } = null!;

        [DisplayName("Nombre")]
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
        public string NombreUsuario { get; set; } = null!;

        [Required]
        [DisplayName("Apellido")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
        public string ApellidoUsuario { get; set; } = null!;

        [Required]
        [DisplayName("Cedula")]
        [RegularExpression(@"^[1-9]\d{8}$", ErrorMessage = "La cédula no tiene un formato válido.")]
        public string CedulaUsuario { get; set; } = null!;

        [Required]
        [DisplayName("Direccion")]
        public string DireccionUsuario { get; set; } = null!;

        [Required]
        [DisplayName("Telefono")]
        [Phone]
        public string TelefonoUsuario { get; set; } = null!;

        [Required]
        [DisplayName("Correo")]
        [EmailAddress(ErrorMessage = "Debe especificar un correo valido")]
        public string CorreoUsuario { get; set; } = null!;
        public decimal PrecioFinal { get; set; }
        public string EstadoFactura { get; set; } = null!;

    }
}
