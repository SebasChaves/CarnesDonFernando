﻿namespace BackEnd.Models
{
    public class RestauranteModel
    {

        public int IdRestaurante { get; set; }
        public string NombreRestaurante { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string Horario { get; set; } = null!;
        public string UrlImg { get; set; } = null!; 
        public string Telefono { get; set; } = null!;

    }
}
