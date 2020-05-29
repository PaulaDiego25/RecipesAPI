namespace RecipesAPI.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RecipesAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipesAPI.Models.RecipesAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RecipesAPI.Models.RecipesAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roles = new List<Role>
            {
                new Role {Id=1, Description = "Administrator"},
                new Role {Id=2, Description = "User"}
            };

            roles.ForEach(s => context.Roles.AddOrUpdate(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User { Id=1, Name = "Paula Diego", Password = "test", Email= "paulitadiego@gmail.com", Alias="Paula", FKRoleId=1}
            };

            users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();

            var recipetypes = new List<RecipeType>
            {
                new RecipeType { Id=1, Description = "Bebidas deliciosas", Title = "Bebida"}
            };

            recipetypes.ForEach(s => context.RecipeTypes.AddOrUpdate(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category { Id=1, Description = "Bebidas frias y refrescantes", Title = "Bebida Fria", FKRecipeTypeId=1}
            };

            categories.ForEach(s => context.Categories.AddOrUpdate(s));
            context.SaveChanges();

            var recipes = new List<Recipe>
            {
                new Recipe {Id=1, FKCategoryId = 1, Title="Limonada", Description = "Esta es una deliciosa limonada sin azucar realfooder",Time=30, IsPublic=false, CreationDate=DateTime.Now}
            };

            recipes.ForEach(s => context.Recipes.AddOrUpdate(s));
            context.SaveChanges();

            var steps = new List<Step>
            {
                new Step { Id=1, FKRecipeId = 1, Title= "Paso 1", Explanation="Verter el agua en una jarra",Order=1},
                new Step { Id=2, FKRecipeId = 1, Title= "Paso 2", Explanation="Exprimir los limones",Order=2},
                new Step { Id=3, FKRecipeId = 1, Title= "Paso 3", Explanation="Verter el jugo de limon en el agua y remover",Order=3},
            };

            steps.ForEach(s => context.Steps.AddOrUpdate(s));
            context.SaveChanges();

            var ingredients = new List<Ingredient>
            {
                new Ingredient { Id=1, Title = "Agua"},
                new Ingredient { Id=2, Title = "Limón"}
            };

            ingredients.ForEach(s => context.Ingredients.AddOrUpdate(s));
            context.SaveChanges();

            var stepIngredients = new List<StepIngredient>
            {
                new StepIngredient { Id=1, FKIngredientId = 1, FKStepId=1, Quantity= 2  },
                new StepIngredient { Id=2, FKIngredientId = 2, FKStepId=2, Quantity=2}
            };

            stepIngredients.ForEach(s => context.StepIngredients.AddOrUpdate(s));
            context.SaveChanges();


                                              

            var userRecipeRatings = new List<UserRecipeRating>
            {
                new UserRecipeRating {FKUserId=1,FKRecipeId=1,IsFavourite=true}
            };

            userRecipeRatings.ForEach(s => context.UserRecipeRatings.AddOrUpdate(s));
            context.SaveChanges();


        }
    }
}
