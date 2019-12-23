
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public ICollection<StepIngredient> StepIngredients { get; set; }
                          
    }
}