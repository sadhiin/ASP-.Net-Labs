namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurentPropertyChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Location", c => c.String());
        }
    }
}
