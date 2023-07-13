namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusDataTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CollectionRequests", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Distributions", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Distributions", "Status", c => c.String());
            AlterColumn("dbo.CollectionRequests", "Status", c => c.String());
        }
    }
}
