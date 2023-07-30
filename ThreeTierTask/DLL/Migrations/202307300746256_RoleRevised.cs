namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleRevised : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "RoleType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "RoleType");
        }
    }
}
