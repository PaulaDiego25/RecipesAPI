using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class Step
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Explanation { get; set; }
        public int Order { get; set; }
        public string Picture { get; set; }
    }
}