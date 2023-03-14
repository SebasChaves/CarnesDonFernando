using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Receta
    {
        public int IdReceta { get; set; }
        public int IdIngrediente { get; set; }
        public string NombreReceta { get; set; } = null!;
        public string DescripcionReceta { get; set; } = null!;

        public virtual Ingrediente IdIngredienteNavigation { get; set; } = null!;
    }
}
