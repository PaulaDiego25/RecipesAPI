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

        public ICollection<Step> FKStepsId { get; set; }
		
        public int FKCategoryId { get; set; }
        public Category FKCategory { get; set; }
		
        public ICollection<UserRecipe> FKUserRecipes { get; set; }
        public ICollection<Rating> FKRatings { get; set; }



    }
}