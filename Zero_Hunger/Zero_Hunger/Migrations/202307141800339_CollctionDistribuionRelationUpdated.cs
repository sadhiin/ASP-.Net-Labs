namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollctionDistribuionRelationUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CollectionRequests", "CollectionRequestId", "dbo.Distributions");
            DropIndex("dbo.CollectionRequests", new[] { "CollectionRequestId" });
            DropPrimaryKey("dbo.CollectionRequests");
            AddColumn("dbo.CollectionRequests", "Distribution_DistributionId", c => c.Int());
            AlterColumn("dbo.CollectionRequests", "CollectionRequestId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CollectionRequests", "CollectionRequestId");
            CreateIndex("dbo.CollectionRequests", "Distribution_DistributionId");
            AddForeignKey("dbo.CollectionRequests", "Distribution_DistributionId", "dbo.Distributions", "DistributionId");
            DropColumn("dbo.Distributions", "CollectionRequestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Distributions", "CollectionRequestId", c => c.Int());
            DropForeignKey("dbo.CollectionRequests", "Distribution_DistributionId", "dbo.Distributions");
            DropIndex("dbo.CollectionRequests", new[] { "Distribution_DistributionId" });
            DropPrimaryKey("dbo.CollectionRequests");
            AlterColumn("dbo.CollectionRequests", "CollectionRequestId", c => c.Int(nullable: false));
            DropColumn("dbo.CollectionRequests", "Distribution_DistributionId");
            AddPrimaryKey("dbo.CollectionRequests", "CollectionRequestId");
            CreateIndex("dbo.CollectionRequests", "CollectionRequestId");
            AddForeignKey("dbo.CollectionRequests", "CollectionRequestId", "dbo.Distributions", "DistributionId");
        }
    }
}
