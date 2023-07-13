namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FreshDBInIt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CollectRequests", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DistributionRecords", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CollectRequests", "NGO_Id", "dbo.NGOes");
            DropForeignKey("dbo.DistributionRecords", "NGO_Id", "dbo.NGOes");
            DropForeignKey("dbo.CollectRequests", "Restaurant_RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "NGOId", "dbo.NGOes");
            DropForeignKey("dbo.Employees", "NGOId", "dbo.NGOes");
            DropIndex("dbo.CollectRequests", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.CollectRequests", new[] { "NGO_Id" });
            DropIndex("dbo.CollectRequests", new[] { "Restaurant_RestaurantId" });
            DropIndex("dbo.DistributionRecords", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.DistributionRecords", new[] { "NGO_Id" });
            DropIndex("dbo.Employees", new[] { "NGOId" });
            DropIndex("dbo.Restaurants", new[] { "NGOId" });
            DropColumn("dbo.Employees", "Username");
            RenameColumn(table: "dbo.Employees", name: "NGOId", newName: "UserName");
            DropPrimaryKey("dbo.NGOes");
            AddColumn("dbo.Restaurants", "RestaurantName", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Employees", "UserName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "Contract", c => c.String());
            AlterColumn("dbo.Employees", "UserName", c => c.String(maxLength: 128));
            AlterColumn("dbo.NGOes", "UserName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.NGOes", "Password", c => c.String());
            AlterColumn("dbo.Restaurants", "UserName", c => c.String());
            AlterColumn("dbo.Restaurants", "Password", c => c.String());
            AlterColumn("dbo.Restaurants", "Address", c => c.String());
            AlterColumn("dbo.Restaurants", "Contract", c => c.String());
            AddPrimaryKey("dbo.NGOes", "UserName");
            CreateIndex("dbo.Employees", "UserName");
            AddForeignKey("dbo.Employees", "UserName", "dbo.NGOes", "UserName");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.NGOes", "Id");
            DropColumn("dbo.NGOes", "Name");
            DropColumn("dbo.NGOes", "Address");
            DropColumn("dbo.NGOes", "Contract");
            DropColumn("dbo.Restaurants", "Name");
            DropColumn("dbo.Restaurants", "Email");
            DropColumn("dbo.Restaurants", "NGOId");
            DropTable("dbo.CollectRequests");
            DropTable("dbo.DistributionRecords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DistributionRecords",
                c => new
                    {
                        DistributionId = c.Int(nullable: false, identity: true),
                        DistributionDate = c.DateTime(nullable: false),
                        DistributionLocation = c.String(nullable: false),
                        Employee_EmployeeId = c.Int(),
                        NGO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.DistributionId);
            
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        CollectRequestId = c.Int(nullable: false, identity: true),
                        MaximumPreservationTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(),
                        NGO_Id = c.Int(),
                        Restaurant_RestaurantId = c.Int(),
                    })
                .PrimaryKey(t => t.CollectRequestId);
            
            AddColumn("dbo.Restaurants", "NGOId", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurants", "Email", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.NGOes", "Contract", c => c.String(nullable: false));
            AddColumn("dbo.NGOes", "Address", c => c.String(maxLength: 100));
            AddColumn("dbo.NGOes", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.NGOes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employees", "Password", c => c.String(nullable: false, maxLength: 32));
            DropForeignKey("dbo.Employees", "UserName", "dbo.NGOes");
            DropIndex("dbo.Employees", new[] { "UserName" });
            DropPrimaryKey("dbo.NGOes");
            AlterColumn("dbo.Restaurants", "Contract", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Restaurants", "Password", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Restaurants", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.NGOes", "Password", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.NGOes", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "UserName", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Contract", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Restaurants", "RestaurantName");
            AddPrimaryKey("dbo.NGOes", "Id");
            RenameColumn(table: "dbo.Employees", name: "UserName", newName: "NGOId");
            AddColumn("dbo.Employees", "Username", c => c.String(nullable: false));
            CreateIndex("dbo.Restaurants", "NGOId");
            CreateIndex("dbo.Employees", "NGOId");
            CreateIndex("dbo.DistributionRecords", "NGO_Id");
            CreateIndex("dbo.DistributionRecords", "Employee_EmployeeId");
            CreateIndex("dbo.CollectRequests", "Restaurant_RestaurantId");
            CreateIndex("dbo.CollectRequests", "NGO_Id");
            CreateIndex("dbo.CollectRequests", "Employee_EmployeeId");
            AddForeignKey("dbo.Employees", "NGOId", "dbo.NGOes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Restaurants", "NGOId", "dbo.NGOes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CollectRequests", "Restaurant_RestaurantId", "dbo.Restaurants", "RestaurantId");
            AddForeignKey("dbo.DistributionRecords", "NGO_Id", "dbo.NGOes", "Id");
            AddForeignKey("dbo.CollectRequests", "NGO_Id", "dbo.NGOes", "Id");
            AddForeignKey("dbo.DistributionRecords", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.CollectRequests", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
