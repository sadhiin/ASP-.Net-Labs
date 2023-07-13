namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeCollctionDistributionAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "UserName", "dbo.NGOes");
            DropIndex("dbo.Employees", new[] { "UserName" });
            CreateTable(
                "dbo.CollectionRequests",
                c => new
                    {
                        CollectionRequestId = c.Int(nullable: false),
                        CollectionRequestName = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        MaxTimeToPreserve = c.DateTime(nullable: false),
                        Status = c.String(),
                        RestaurantId = c.Int(nullable: false),
                        EmpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CollectionRequestId)
                .ForeignKey("dbo.Distributions", t => t.CollectionRequestId)
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.CollectionRequestId)
                .Index(t => t.RestaurantId)
                .Index(t => t.EmpId);
            
            CreateTable(
                "dbo.Distributions",
                c => new
                    {
                        DistributionId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        CollectionRequestId = c.Int(),
                        DistributionTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.DistributionId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            AddColumn("dbo.Employees", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Restaurants", "Location", c => c.String());
            AlterColumn("dbo.Employees", "UserName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Employees", "Contract", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "UserName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "UserName");
            CreateIndex("dbo.Restaurants", "UserName");
            AddForeignKey("dbo.Restaurants", "UserName", "dbo.NGOes", "UserName");
            AddForeignKey("dbo.Employees", "UserName", "dbo.NGOes", "UserName", cascadeDelete: true);
            DropColumn("dbo.Restaurants", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Address", c => c.String());
            DropForeignKey("dbo.Employees", "UserName", "dbo.NGOes");
            DropForeignKey("dbo.Restaurants", "UserName", "dbo.NGOes");
            DropForeignKey("dbo.CollectionRequests", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.CollectionRequests", "EmpId", "dbo.Employees");
            DropForeignKey("dbo.Distributions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CollectionRequests", "CollectionRequestId", "dbo.Distributions");
            DropIndex("dbo.Restaurants", new[] { "UserName" });
            DropIndex("dbo.Employees", new[] { "UserName" });
            DropIndex("dbo.Distributions", new[] { "EmployeeId" });
            DropIndex("dbo.CollectionRequests", new[] { "EmpId" });
            DropIndex("dbo.CollectionRequests", new[] { "RestaurantId" });
            DropIndex("dbo.CollectionRequests", new[] { "CollectionRequestId" });
            AlterColumn("dbo.Restaurants", "UserName", c => c.String());
            AlterColumn("dbo.Employees", "Contract", c => c.String());
            AlterColumn("dbo.Employees", "UserName", c => c.String(maxLength: 128));
            DropColumn("dbo.Restaurants", "Location");
            DropColumn("dbo.Employees", "Password");
            DropTable("dbo.Distributions");
            DropTable("dbo.CollectionRequests");
            CreateIndex("dbo.Employees", "UserName");
            AddForeignKey("dbo.Employees", "UserName", "dbo.NGOes", "UserName");
        }
    }
}
