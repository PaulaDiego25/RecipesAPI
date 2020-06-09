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
                new RecipeType { Id=1, Description = "Todo tipo de bebidas", Title = "Bebida"},
                new RecipeType { Id=2, Description = "Para tomar antes de un plato principal", Title = "Entrantes"},
                new RecipeType { Id=3, Description = "", Title = "Platos principales"},
                new RecipeType { Id=4, Description = "Comidas de acompañamiento a platos principales", Title = "Complementos"},
                new RecipeType { Id=5, Description = "Para finalizar la comida", Title = "Postres"},
            };

            recipetypes.ForEach(s => context.RecipeTypes.AddOrUpdate(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category { Id=1, Description = "Bebidas frias y refrescantes", Title = "Refrescos", FKRecipeTypeId=1},
                new Category { Id=2, Description = "Bebida obtenida de las hojas, las flores, las raíces, las cortezas, los frutos o las semillas de ciertas hierbas y plantas", Title = "Infusiones", FKRecipeTypeId=1},
                new Category { Id=3, Description = "Bebida elaborada a base de leche, puede ser frio o caliente", Title = "Batidos", FKRecipeTypeId=1},

                new Category { Id=4, Description = "", Title = "Entrantes frios", FKRecipeTypeId=2},
                new Category { Id=5, Description = "", Title = "Entrantes calientes", FKRecipeTypeId=2},

                new Category { Id=6, Description = "", Title = "Mariscos", FKRecipeTypeId=3},
                new Category { Id=7, Description = "", Title = "Carnes", FKRecipeTypeId=3},
                new Category { Id=8, Description = "", Title = "Pastas", FKRecipeTypeId=3},
                new Category { Id=9, Description = "", Title = "Arroces", FKRecipeTypeId=3},
                new Category { Id=10, Description = "", Title = "Pescados", FKRecipeTypeId=3},
                new Category { Id=11, Description = "", Title = "Guisos", FKRecipeTypeId=3},

                
                new Category { Id=12, Description = "", Title = "Ensaladas", FKRecipeTypeId=4},
                new Category { Id=13, Description = "", Title = "Salsas", FKRecipeTypeId=4},
                new Category { Id=14, Description = "", Title = "Encurtidos", FKRecipeTypeId=4},

                new Category { Id=12, Description = "", Title = "Helados", FKRecipeTypeId=5},
                new Category { Id=13, Description = "", Title = "Lacteos", FKRecipeTypeId=5},
                new Category { Id=14, Description = "", Title = "Frutas", FKRecipeTypeId=5},
                new Category { Id=15, Description = "", Title = "Bollería", FKRecipeTypeId=5},

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
                new Ingredient { Id=2, Title = "Limón"},
                new Ingredient { Id=3, Title = "Harina"},
                new Ingredient { Id=4, Title = "Aceite"},
                new Ingredient { Id=5, Title = "Azúcar"},
                new Ingredient { Id=6, Title = "Levadura"},
                new Ingredient { Id=7, Title = "Leche"},
                new Ingredient { Id=8, Title = "Menta"},
                new Ingredient { Id=9, Title = "Jenjibre"}

            };

            ingredients.ForEach(s => context.Ingredients.AddOrUpdate(s));
            context.SaveChanges();

            var stepIngredients = new List<StepIngredient>
            {
                new StepIngredient { Id=1, FKIngredientId = 1, FKStepId=1, Quantity= "1,5 litros" },
                new StepIngredient { Id=2, FKIngredientId = 2, FKStepId=2, Quantity= "2 unidades"}
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
