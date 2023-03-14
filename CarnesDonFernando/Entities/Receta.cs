using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Receta
    {
        public Receta()
        {
            Ingredientes = new HashSet<Ingrediente>();
        }

        public int IdReceta { get; set; }
        public string NombreReceta { get; set; } = null!;
        public string UrlImg { get; set; } = null!;
        public string DescripcionReceta { get; set; } = null!;

        public virtual ICollection<Ingrediente> Ingredientes { get; set; }
    }
}
