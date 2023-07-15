namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectionRequestandEmpIdIssueSolved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CollectionRequests", "EmpId", "dbo.Employees");
            DropIndex("dbo.CollectionRequests", new[] { "EmpId" });
            AlterColumn("dbo.CollectionRequests", "EmpId", c => c.Int());
            CreateIndex("dbo.CollectionRequests", "EmpId");
            AddForeignKey("dbo.CollectionRequests", "EmpId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionRequests", "EmpId", "dbo.Employees");
            DropIndex("dbo.CollectionRequests", new[] { "EmpId" });
            AlterColumn("dbo.CollectionRequests", "EmpId", c => c.Int(nullable: false));
            CreateIndex("dbo.CollectionRequests", "EmpId");
            AddForeignKey("dbo.CollectionRequests", "EmpId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
