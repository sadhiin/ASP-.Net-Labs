namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTypeAndRequiredAddedEmpRest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "RestaurantName", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Contract", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Contract", c => c.String());
            AlterColumn("dbo.Restaurants", "Password", c => c.String());
            AlterColumn("dbo.Restaurants", "UserName", c => c.String());
            AlterColumn("dbo.Restaurants", "RestaurantName", c => c.String());
        }
    }
}
