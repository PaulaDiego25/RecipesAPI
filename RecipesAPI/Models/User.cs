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

        public ICollection<UserRecipe> FKUserRecipes { get; set; }

        public int FKRoleId { get; set; }
        public Role FKRole { get; set; }

        public ICollection<Rating> FKRatings { get; set; }


    }
}