namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Category_CategoryId", c => c.Int());
            AddColumn("dbo.Members", "Project_ProjectId", c => c.Int());
            AddColumn("dbo.Members", "Enrollment_ID", c => c.Int());
            CreateIndex("dbo.Projects", "Category_CategoryId");
            CreateIndex("dbo.Members", "Project_ProjectId");
            CreateIndex("dbo.Members", "Enrollment_ID");
            AddForeignKey("dbo.Members", "Project_ProjectId", "dbo.Projects", "ProjectId");
            AddForeignKey("dbo.Projects", "Category_CategoryId", "dbo.Categories", "CategoryId");
            AddForeignKey("dbo.Members", "Enrollment_ID", "dbo.Enrollments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Enrollment_ID", "dbo.Enrollments");
            DropForeignKey("dbo.Projects", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Members", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Members", new[] { "Enrollment_ID" });
            DropIndex("dbo.Members", new[] { "Project_ProjectId" });
            DropIndex("dbo.Projects", new[] { "Category_CategoryId" });
            DropColumn("dbo.Members", "Enrollment_ID");
            DropColumn("dbo.Members", "Project_ProjectId");
            DropColumn("dbo.Projects", "Category_CategoryId");
        }
    }
}
