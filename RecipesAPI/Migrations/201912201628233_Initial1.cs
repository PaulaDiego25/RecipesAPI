namespace RecipesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Test", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Test");
        }
    }
}
