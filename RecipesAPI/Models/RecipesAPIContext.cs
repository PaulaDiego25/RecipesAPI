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

        public System.Data.Entity.DbSet<RecipesAPI.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.Step> Steps { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.Ingredient> Ingredients { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.UserRecipeRating> UserRecipeRatings { get; set; }

        public System.Data.Entity.DbSet<RecipesAPI.Models.StepIngredient> StepIngredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<StepIngredient>()
                .HasRequired<Ingredient>(s => s.FKIngredient)
                .WithMany(i => i.FKStepIngredients)
                .HasForeignKey<int>(s => s.FKIngredientId);

            modelBuilder.Entity<StepIngredient>()
                .HasRequired<Step>(s => s.FKStep)
                .WithMany(i => i.FKStepIngredients)
                .HasForeignKey<int>(s => s.FKStepId);

            modelBuilder.Entity<Step>()
                .HasRequired<Recipe>(s => s.FKRecipe)
                .WithMany(r => r.FKStepsId)
                .HasForeignKey<int>(s => s.FKRecipeId);

            modelBuilder.Entity<Recipe>()
                .HasRequired<Category>(r => r.FKCategory)
                .WithMany(c => c.FKRecipes)
                .HasForeignKey<int>(r => r.FKCategoryId);

            modelBuilder.Entity<Category>()
                .HasRequired<RecipeType>(c => c.FKRecipeType)
                .WithMany(t => t.FKCategories)
                .HasForeignKey<int>(c => c.FKRecipeTypeId);

            modelBuilder.Entity<UserRecipeRating>()
               .HasRequired<Recipe>(u => u.FKRecipe)
               .WithMany(r => r.FKUserRecipeRatings)
               .HasForeignKey<int>(u => u.FKRecipeId);

            modelBuilder.Entity<UserRecipeRating>()
              .HasRequired<User>(u => u.FKUser)
              .WithMany(r => r.FKUserRecipes)
              .HasForeignKey<int>(u => u.FKUserId);

            modelBuilder.Entity<User>()
              .HasRequired<Role>(u => u.FKRole)
              .WithMany(r => r.Users)
              .HasForeignKey<int>(u => u.FKRoleId);

            modelBuilder.Entity<Comment>()
              .HasRequired<User>(r => r.FKUser)
              .WithMany(u => u.FKRatings)
              .HasForeignKey<int>(r => r.FKUserId);

            modelBuilder.Entity<Comment>()
              .HasRequired<Recipe>(r => r.FKRecipe)
              .WithMany(re => re.FKRatings)
              .HasForeignKey<int>(r => r.FKRecipeId);


        }
    }
}

