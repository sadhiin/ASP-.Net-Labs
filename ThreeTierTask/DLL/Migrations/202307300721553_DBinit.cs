namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Status = c.Int(nullable: false),
                        SupervisorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Supervisors", t => t.SupervisorId, cascadeDelete: true)
                .Index(t => t.SupervisorId);
            
            CreateTable(
                "dbo.Supervisors",
                c => new
                    {
                        SupervisorId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.SupervisorId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "SupervisorId", "dbo.Supervisors");
            DropIndex("dbo.Projects", new[] { "SupervisorId" });
            DropIndex("dbo.Enrollments", new[] { "ProjectId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Members");
            DropTable("dbo.Supervisors");
            DropTable("dbo.Projects");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Categories");
        }
    }
}
