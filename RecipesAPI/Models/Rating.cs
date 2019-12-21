using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}