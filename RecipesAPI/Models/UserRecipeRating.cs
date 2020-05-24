using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class UserRecipeRating
    {
        public int Id { get; set; }
        public bool IsFavourite { get; set; }
        public int Score { get; set; }

        public int FKRecipeId{ get; set; }
        public Recipe FKRecipe { get; set; }

        public int FKUserId { get; set; }
        public User FKUser { get; set; }
    }
}