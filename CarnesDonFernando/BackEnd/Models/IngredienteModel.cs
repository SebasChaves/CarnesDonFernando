﻿using Entities;

namespace BackEnd.Models
{
    public class IngredienteModel
    {

        public int IdIngrediente { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdReceta { get; set; }

        //public virtual Receta IdRecetaNavigation { get; set; } = null!;

    }
}
