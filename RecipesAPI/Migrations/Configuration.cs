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
                new Role { Description = "Administrator"},
                new Role { Description = "User"}
            };

            roles.ForEach(s => context.Roles.AddOrUpdate(p => p.Description, s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User { Name = "Paula Diego", Password = "test", Email= "paulitadiego@gmail.com", Alias="Paula", IdRole=1}
            };

            users.ForEach(s => context.Users.AddOrUpdate(p => p.Alias, s));
            context.SaveChanges();

            var recipetypes = new List<RecipeType>
            {
                new RecipeType {  Description = "Esta es una categoria de prueba", Title = "Bebida"}
            };

            recipetypes.ForEach(s => context.RecipeTypes.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category {  Description = "Esta es un tipo de prueba", Title = "Bebida Fria", IdRecipeType=1}
            };

            categories.ForEach(s => context.Categories.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var ingredients = new List<Ingredient>
            {
                new Ingredient { Title = "Agua"},
                new Ingredient { Title = "Limón"}
            };

            ingredients.ForEach(s => context.Ingredients.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var stepIngredients = new List<StepIngredient>
            {
                new StepIngredient { IdIngredient = 1, Quantity= 2},
                new StepIngredient { IdIngredient = 2, Quantity=1}
            };

            stepIngredients.ForEach(s => context.StepIngredients.AddOrUpdate(p => p.IdIngredient, s));
            context.SaveChanges();
        }
    }
}
