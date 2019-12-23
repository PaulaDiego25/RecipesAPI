using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class UserRecipe
    {
        public int Id { get; set; }
        public bool IsFavourite { get; set; }
        public int Score { get; set; }

        public int IdRecipe { get; set; }
        public Recipe Recipe { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }
    }
}