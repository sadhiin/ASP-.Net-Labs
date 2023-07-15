namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolvingDBIssueWithNewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectionRequests",
                c => new
                    {
                        CollectionRequestId = c.Int(nullable: false, identity: true),
                        CollectionRequestName = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        MaxTimeToPreserve = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        EmpId = c.Int(nullable: false),
                        Distribution_DistributionId = c.Int(),
                    })
                .PrimaryKey(t => t.CollectionRequestId)
                .ForeignKey("dbo.Distributions", t => t.Distribution_DistributionId)
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.EmpId)
                .Index(t => t.Distribution_DistributionId);
            
            CreateTable(
                "dbo.Distributions",
                c => new
                    {
                        DistributionId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        DistributionTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistributionId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Contract = c.String(nullable: false),
                        NGOUsername = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.NGOes", t => t.NGOUsername)
                .Index(t => t.NGOUsername);
            
            CreateTable(
                "dbo.NGOes",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Contract = c.String(nullable: false),
                        NGOUsername = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RestaurantID)
                .ForeignKey("dbo.NGOes", t => t.NGOUsername)
                .Index(t => t.NGOUsername);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionRequests", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.CollectionRequests", "EmpId", "dbo.Employees");
            DropForeignKey("dbo.Distributions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "NGOUsername", "dbo.NGOes");
            DropForeignKey("dbo.Restaurants", "NGOUsername", "dbo.NGOes");
            DropForeignKey("dbo.CollectionRequests", "Distribution_DistributionId", "dbo.Distributions");
            DropIndex("dbo.Restaurants", new[] { "NGOUsername" });
            DropIndex("dbo.Employees", new[] { "NGOUsername" });
            DropIndex("dbo.Distributions", new[] { "EmployeeId" });
            DropIndex("dbo.CollectionRequests", new[] { "Distribution_DistributionId" });
            DropIndex("dbo.CollectionRequests", new[] { "EmpId" });
            DropIndex("dbo.CollectionRequests", new[] { "RestaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.NGOes");
            DropTable("dbo.Employees");
            DropTable("dbo.Distributions");
            DropTable("dbo.CollectionRequests");
        }
    }
}
