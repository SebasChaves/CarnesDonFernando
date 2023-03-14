using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Restaurante
    {
        public int IdRestaurante { get; set; }
        public string NombreRestaurante { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string Horario { get; set; } = null!;
        public string UrlImg { get; set; } = null!;
    }
}
