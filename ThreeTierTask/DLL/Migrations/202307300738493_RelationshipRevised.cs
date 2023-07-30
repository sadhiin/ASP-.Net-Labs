namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipRevised : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supervisors", "Name", c => c.String());
            AddColumn("dbo.Members", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Name");
            DropColumn("dbo.Supervisors", "Name");
        }
    }
}
