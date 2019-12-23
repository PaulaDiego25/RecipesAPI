namespace RecipesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false, unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        IdUser = c.Int(nullable: false),
                        IdRecipe = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.IdRecipe, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser)
                .Index(t => t.IdRecipe);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Password = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Alias = c.String(unicode: false),
                        IdRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.IdRole, cascadeDelete: true)
                .Index(t => t.IdRole);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRecipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsFavourite = c.Boolean(nullable: false),
                        Score = c.Int(nullable: false),
                        IdRecipe = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.IdRecipe, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdRecipe)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Explanation = c.String(unicode: false),
                        Order = c.Int(nullable: false),
                        Picture = c.String(unicode: false),
                        IdRecipe = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.IdRecipe, cascadeDelete: true)
                .Index(t => t.IdRecipe);
            
            CreateTable(
                "dbo.StepIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Double(nullable: false),
                        IdIngredient = c.Int(nullable: false),
                        IdStep = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IdIngredient, cascadeDelete: true)
                .ForeignKey("dbo.Steps", t => t.IdStep, cascadeDelete: true)
                .Index(t => t.IdIngredient)
                .Index(t => t.IdStep);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "IdRecipeType", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "IdCategory", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "IdRecipeType");
            CreateIndex("dbo.Recipes", "IdCategory");
            AddForeignKey("dbo.Recipes", "IdCategory", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Categories", "IdRecipeType", "dbo.RecipeTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Recipes", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Test", c => c.String(unicode: false));
            DropForeignKey("dbo.Categories", "IdRecipeType", "dbo.RecipeTypes");
            DropForeignKey("dbo.StepIngredients", "IdStep", "dbo.Steps");
            DropForeignKey("dbo.StepIngredients", "IdIngredient", "dbo.Ingredients");
            DropForeignKey("dbo.Steps", "IdRecipe", "dbo.Recipes");
            DropForeignKey("dbo.Ratings", "IdUser", "dbo.Users");
            DropForeignKey("dbo.UserRecipes", "IdUser", "dbo.Users");
            DropForeignKey("dbo.UserRecipes", "IdRecipe", "dbo.Recipes");
            DropForeignKey("dbo.Users", "IdRole", "dbo.Roles");
            DropForeignKey("dbo.Ratings", "IdRecipe", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "IdCategory", "dbo.Categories");
            DropIndex("dbo.StepIngredients", new[] { "IdStep" });
            DropIndex("dbo.StepIngredients", new[] { "IdIngredient" });
            DropIndex("dbo.Steps", new[] { "IdRecipe" });
            DropIndex("dbo.UserRecipes", new[] { "IdUser" });
            DropIndex("dbo.UserRecipes", new[] { "IdRecipe" });
            DropIndex("dbo.Users", new[] { "IdRole" });
            DropIndex("dbo.Ratings", new[] { "IdRecipe" });
            DropIndex("dbo.Ratings", new[] { "IdUser" });
            DropIndex("dbo.Recipes", new[] { "IdCategory" });
            DropIndex("dbo.Categories", new[] { "IdRecipeType" });
            DropColumn("dbo.Recipes", "IdCategory");
            DropColumn("dbo.Categories", "IdRecipeType");
            DropTable("dbo.Ingredients");
            DropTable("dbo.StepIngredients");
            DropTable("dbo.Steps");
            DropTable("dbo.UserRecipes");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Ratings");
        }
    }
}
