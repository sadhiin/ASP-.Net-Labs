namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NGOpasswordDatatypedeclared : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NGOes", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NGOes", "Password", c => c.String());
        }
    }
}
