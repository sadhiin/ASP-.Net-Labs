namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NGO_EMP_RESTAURENT_Relations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectRequests", "NGO_Id", c => c.Int());
            AddColumn("dbo.CollectRequests", "Restaurant_RestaurantId", c => c.Int());
            AddColumn("dbo.DistributionRecords", "NGO_Id", c => c.Int());
            AddColumn("dbo.Restaurants", "NGOId", c => c.Int(nullable: false));
            CreateIndex("dbo.CollectRequests", "NGO_Id");
            CreateIndex("dbo.CollectRequests", "Restaurant_RestaurantId");
            CreateIndex("dbo.DistributionRecords", "NGO_Id");
            CreateIndex("dbo.Restaurants", "NGOId");
            AddForeignKey("dbo.CollectRequests", "NGO_Id", "dbo.NGOes", "Id");
            AddForeignKey("dbo.DistributionRecords", "NGO_Id", "dbo.NGOes", "Id");
            AddForeignKey("dbo.CollectRequests", "Restaurant_RestaurantId", "dbo.Restaurants", "RestaurantId");
            AddForeignKey("dbo.Restaurants", "NGOId", "dbo.NGOes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "NGOId", "dbo.NGOes");
            DropForeignKey("dbo.CollectRequests", "Restaurant_RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.DistributionRecords", "NGO_Id", "dbo.NGOes");
            DropForeignKey("dbo.CollectRequests", "NGO_Id", "dbo.NGOes");
            DropIndex("dbo.Restaurants", new[] { "NGOId" });
            DropIndex("dbo.DistributionRecords", new[] { "NGO_Id" });
            DropIndex("dbo.CollectRequests", new[] { "Restaurant_RestaurantId" });
            DropIndex("dbo.CollectRequests", new[] { "NGO_Id" });
            DropColumn("dbo.Restaurants", "NGOId");
            DropColumn("dbo.DistributionRecords", "NGO_Id");
            DropColumn("dbo.CollectRequests", "Restaurant_RestaurantId");
            DropColumn("dbo.CollectRequests", "NGO_Id");
        }
    }
}
