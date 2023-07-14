namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurentNGOMissingRelationAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurants", "UserName", "dbo.NGOes");
            DropIndex("dbo.Restaurants", new[] { "UserName" });
            AddColumn("dbo.Restaurants", "NGOUsername", c => c.String(maxLength: 128));
            AlterColumn("dbo.Restaurants", "UserName", c => c.String());
            CreateIndex("dbo.Restaurants", "NGOUsername");
            AddForeignKey("dbo.Restaurants", "NGOUsername", "dbo.NGOes", "UserName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "NGOUsername", "dbo.NGOes");
            DropIndex("dbo.Restaurants", new[] { "NGOUsername" });
            AlterColumn("dbo.Restaurants", "UserName", c => c.String(maxLength: 128));
            DropColumn("dbo.Restaurants", "NGOUsername");
            CreateIndex("dbo.Restaurants", "UserName");
            AddForeignKey("dbo.Restaurants", "UserName", "dbo.NGOes", "UserName");
        }
    }
}
