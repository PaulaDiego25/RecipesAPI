using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public int FKUserId { get; set; }
        public User FKUser { get; set; }

        public int FKRecipeId { get; set; }
        public Recipe FKRecipe { get; set; }
    }
}