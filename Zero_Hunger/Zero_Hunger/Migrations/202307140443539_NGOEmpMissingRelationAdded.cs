namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NGOEmpMissingRelationAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "UserName", "dbo.NGOes");
            DropIndex("dbo.Employees", new[] { "UserName" });
            AddColumn("dbo.Employees", "NGOUsername", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "UserName", c => c.String(nullable: false));
            CreateIndex("dbo.Employees", "NGOUsername");
            AddForeignKey("dbo.Employees", "NGOUsername", "dbo.NGOes", "UserName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "NGOUsername", "dbo.NGOes");
            DropIndex("dbo.Employees", new[] { "NGOUsername" });
            AlterColumn("dbo.Employees", "UserName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Employees", "NGOUsername");
            CreateIndex("dbo.Employees", "UserName");
            AddForeignKey("dbo.Employees", "UserName", "dbo.NGOes", "UserName", cascadeDelete: true);
        }
    }
}
