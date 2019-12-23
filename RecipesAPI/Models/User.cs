using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email {get; set; }
        public string Alias { get; set; }

        public ICollection<UserRecipe> UserRecipes { get; set; }

        public int IdRole { get; set; }
        public Role Role { get; set; }

        public ICollection<Rating> Ratings { get; set; }


    }
}