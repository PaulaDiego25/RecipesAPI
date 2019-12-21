using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class RecipesAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RecipesAPIContext() : base("name=RecipesAPIContext")
        {
        }

        public System.Data.Entity.DbSet<RecipesAPI.Models.Recipe> Recipes { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.RecipeType> RecipeTypes { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.Rating> Ratings { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.Step> Steps { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.Ingredient> Ingredients { get; set; }
    }
}
