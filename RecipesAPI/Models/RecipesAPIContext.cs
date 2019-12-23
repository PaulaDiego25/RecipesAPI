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

        public System.Data.Entity.DbSet<RecipesAPI.Models.UserRecipe> UserRecipes { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.StepIngredient> StepIngredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<StepIngredient>()
                .HasRequired<Ingredient>(s => s.Ingredient)
                .WithMany(i => i.StepIngredients)
                .HasForeignKey<int>(s => s.IdIngredient);

            modelBuilder.Entity<StepIngredient>()
                .HasRequired<Step>(s => s.Step)
                .WithMany(i => i.StepIngredients)
                .HasForeignKey<int>(s => s.IdStep);

            modelBuilder.Entity<Step>()
                .HasRequired<Recipe>(s => s.Recipe)
                .WithMany(r => r.Steps)
                .HasForeignKey<int>(s => s.IdRecipe);

            modelBuilder.Entity<Recipe>()
                .HasRequired<Category>(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey<int>(r => r.IdCategory);

            modelBuilder.Entity<Category>()
                .HasRequired<RecipeType>(c => c.RecipeType)
                .WithMany(t => t.Categories)
                .HasForeignKey<int>(c => c.IdRecipeType);

            modelBuilder.Entity<UserRecipe>()
               .HasRequired<Recipe>(u => u.Recipe)
               .WithMany(r => r.UserRecipes)
               .HasForeignKey<int>(u => u.IdRecipe);

            modelBuilder.Entity<UserRecipe>()
              .HasRequired<User>(u => u.User)
              .WithMany(r => r.UserRecipes)
              .HasForeignKey<int>(u => u.IdUser);

            modelBuilder.Entity<User>()
              .HasRequired<Role>(u => u.Role)
              .WithMany(r => r.Users)
              .HasForeignKey<int>(u => u.IdRole);

            modelBuilder.Entity<Rating>()
              .HasRequired<User>(r => r.User)
              .WithMany(u => u.Ratings)
              .HasForeignKey<int>(r => r.IdUser);

            modelBuilder.Entity<Rating>()
              .HasRequired<Recipe>(r => r.Recipe)
              .WithMany(re => re.Ratings)
              .HasForeignKey<int>(r => r.IdRecipe);


        }
    }
}

