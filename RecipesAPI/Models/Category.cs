using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
		
        public ICollection<Recipe> FKRecipes { get; set; }
        public int FKRecipeTypeId { get; set; }
        public RecipeType FKRecipeType { get; set; }
    }
}