using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }
        public string Picture { get; set; }
        public string IsPublic { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<Step> Steps { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public ICollection<UserRecipe> UserRecipes { get; set; }
        public ICollection<Rating> Ratings { get; set; }



    }
}