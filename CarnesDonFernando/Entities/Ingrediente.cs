using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Ingrediente
    {
        public int IdIngrediente { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdReceta { get; set; }

        public virtual Receta IdRecetaNavigation { get; set; } = null!;
    }
}
