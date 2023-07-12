namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInIt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        CollectRequestId = c.Int(nullable: false, identity: true),
                        MaximumPreservationTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.CollectRequestId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.DistributionRecords",
                c => new
                    {
                        DistributionId = c.Int(nullable: false, identity: true),
                        DistributionDate = c.DateTime(nullable: false),
                        DistributionLocation = c.String(nullable: false),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.DistributionId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 32),
                        Contract = c.String(nullable: false),
                        NGOId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.NGOes", t => t.NGOId, cascadeDelete: true)
                .Index(t => t.NGOId);
            
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
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "NGOId", "dbo.NGOes");
            DropForeignKey("dbo.DistributionRecords", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CollectRequests", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "NGOId" });
            DropIndex("dbo.DistributionRecords", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.CollectRequests", new[] { "Employee_EmployeeId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.NGOes");
            DropTable("dbo.Employees");
            DropTable("dbo.DistributionRecords");
            DropTable("dbo.CollectRequests");
        }
    }
}
