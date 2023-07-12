namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        CollectRequestId = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        MaximumPreservationTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ResturentId = c.Int(nullable: false),
                        EmpId = c.Int(nullable: false),
                        Restaurant_RestaurantId = c.Int(),
                    })
                .PrimaryKey(t => t.CollectRequestId)
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_RestaurantId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.ResturentId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.ResturentId)
                .Index(t => t.EmpId)
                .Index(t => t.Restaurant_RestaurantId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Username = c.String(),
                        Contract = c.String(nullable: false),
                        NGOId = c.Int(nullable: false),
                        CollectionReuestId = c.Int(nullable: false),
                        DistributionRecord_DistributionRecordId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.NGOes", t => t.NGOId, cascadeDelete: true)
                .ForeignKey("dbo.DistributionRecords", t => t.DistributionRecord_DistributionRecordId)
                .Index(t => t.NGOId)
                .Index(t => t.DistributionRecord_DistributionRecordId);
            
            CreateTable(
                "dbo.NGOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 32),
                        Address = c.String(maxLength: 100),
                        Contract = c.String(nullable: false),
                        EmpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 32),
                        Address = c.String(nullable: false, maxLength: 100),
                        Contract = c.String(nullable: false),
                        CollctiontId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            CreateTable(
                "dbo.DistributionRecords",
                c => new
                    {
                        DistributionRecordId = c.Int(nullable: false, identity: true),
                        DistributionDate = c.DateTime(nullable: false),
                        DistributionLocation = c.String(nullable: false),
                        CollectRequestId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistributionRecordId)
                .ForeignKey("dbo.CollectRequests", t => t.CollectRequestId, cascadeDelete: true)
                .Index(t => t.CollectRequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DistributionRecord_DistributionRecordId", "dbo.DistributionRecords");
            DropForeignKey("dbo.DistributionRecords", "CollectRequestId", "dbo.CollectRequests");
            DropForeignKey("dbo.CollectRequests", "ResturentId", "dbo.Restaurants");
            DropForeignKey("dbo.CollectRequests", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.CollectRequests", "Restaurant_RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.CollectRequests", "EmpId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "NGOId", "dbo.NGOes");
            DropIndex("dbo.DistributionRecords", new[] { "CollectRequestId" });
            DropIndex("dbo.Employees", new[] { "DistributionRecord_DistributionRecordId" });
            DropIndex("dbo.Employees", new[] { "NGOId" });
            DropIndex("dbo.CollectRequests", new[] { "Restaurant_RestaurantId" });
            DropIndex("dbo.CollectRequests", new[] { "EmpId" });
            DropIndex("dbo.CollectRequests", new[] { "ResturentId" });
            DropIndex("dbo.CollectRequests", new[] { "RestaurantId" });
            DropTable("dbo.DistributionRecords");
            DropTable("dbo.Restaurants");
            DropTable("dbo.NGOes");
            DropTable("dbo.Employees");
            DropTable("dbo.CollectRequests");
        }
    }
}
