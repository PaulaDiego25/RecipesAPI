namespace RecipesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datos01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "IsPublic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "IsPublic", c => c.String(unicode: false));
        }
    }
}
