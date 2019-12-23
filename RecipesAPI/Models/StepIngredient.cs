using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class StepIngredient
    {
        public int Id { get; set; }
             
        public double Quantity { get; set; }

        public int IdIngredient { get; set; }
        public Ingredient  Ingredient { get; set; }

        public int IdStep{ get; set; }
        public Step Step { get; set; }

    }
}