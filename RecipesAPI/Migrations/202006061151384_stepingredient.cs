namespace RecipesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stepingredient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(unicode: false),
                        FKRecipeTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipeTypes", t => t.FKRecipeTypeId, cascadeDelete: true)
                .Index(t => t.FKRecipeTypeId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(unicode: false),
                        Time = c.Double(nullable: false),
                        Picture = c.String(unicode: false),
                        IsPublic = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 0),
                        FKCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.FKCategoryId, cascadeDelete: true)
                .Index(t => t.FKCategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        FKUserId = c.Int(nullable: false),
                        FKRecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.FKRecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.FKUserId, cascadeDelete: true)
                .Index(t => t.FKUserId)
                .Index(t => t.FKRecipeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Password = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Alias = c.String(unicode: false),
                        FKRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.FKRoleId, cascadeDelete: true)
                .Index(t => t.FKRoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRecipeRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsFavourite = c.Boolean(nullable: false),
                        Score = c.Int(nullable: false),
                        FKRecipeId = c.Int(nullable: false),
                        FKUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.FKRecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.FKUserId, cascadeDelete: true)
                .Index(t => t.FKRecipeId)
                .Index(t => t.FKUserId);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Explanation = c.String(unicode: false),
                        Order = c.Int(nullable: false),
                        Picture = c.String(unicode: false),
                        FKRecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.FKRecipeId, cascadeDelete: true)
                .Index(t => t.FKRecipeId);
            
            CreateTable(
                "dbo.StepIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.String(unicode: false),
                        FKIngredientId = c.Int(nullable: false),
                        FKStepId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.FKIngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Steps", t => t.FKStepId, cascadeDelete: true)
                .Index(t => t.FKIngredientId)
                .Index(t => t.FKStepId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "FKRecipeTypeId", "dbo.RecipeTypes");
            DropForeignKey("dbo.StepIngredients", "FKStepId", "dbo.Steps");
            DropForeignKey("dbo.StepIngredients", "FKIngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Steps", "FKRecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Comments", "FKUserId", "dbo.Users");
            DropForeignKey("dbo.UserRecipeRatings", "FKUserId", "dbo.Users");
            DropForeignKey("dbo.UserRecipeRatings", "FKRecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Users", "FKRoleId", "dbo.Roles");
            DropForeignKey("dbo.Comments", "FKRecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "FKCategoryId", "dbo.Categories");
            DropIndex("dbo.StepIngredients", new[] { "FKStepId" });
            DropIndex("dbo.StepIngredients", new[] { "FKIngredientId" });
            DropIndex("dbo.Steps", new[] { "FKRecipeId" });
            DropIndex("dbo.UserRecipeRatings", new[] { "FKUserId" });
            DropIndex("dbo.UserRecipeRatings", new[] { "FKRecipeId" });
            DropIndex("dbo.Users", new[] { "FKRoleId" });
            DropIndex("dbo.Comments", new[] { "FKRecipeId" });
            DropIndex("dbo.Comments", new[] { "FKUserId" });
            DropIndex("dbo.Recipes", new[] { "FKCategoryId" });
            DropIndex("dbo.Categories", new[] { "FKRecipeTypeId" });
            DropTable("dbo.RecipeTypes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.StepIngredients");
            DropTable("dbo.Steps");
            DropTable("dbo.UserRecipeRatings");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Recipes");
            DropTable("dbo.Categories");
        }
    }
}
