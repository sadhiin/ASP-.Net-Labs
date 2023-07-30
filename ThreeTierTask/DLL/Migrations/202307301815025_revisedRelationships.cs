namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revisedRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Members", "Enrollment_ID", "dbo.Enrollments");
            DropForeignKey("dbo.Projects", "SupervisorId", "dbo.Supervisors");
            DropIndex("dbo.Projects", new[] { "SupervisorId" });
            DropIndex("dbo.Members", new[] { "Project_ProjectId" });
            DropIndex("dbo.Members", new[] { "Enrollment_ID" });
            RenameColumn(table: "dbo.Projects", name: "SupervisorId", newName: "Supervisor_SupervisorId");
            AddColumn("dbo.Projects", "Supervisor_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Enrollments", "Member_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Enrollments", "Member_MemberId", c => c.Int());
            AlterColumn("dbo.Projects", "Supervisor_SupervisorId", c => c.Int());
            CreateIndex("dbo.Projects", "Supervisor_SupervisorId");
            CreateIndex("dbo.Enrollments", "Member_MemberId");
            AddForeignKey("dbo.Enrollments", "Member_MemberId", "dbo.Members", "MemberId");
            AddForeignKey("dbo.Projects", "Supervisor_SupervisorId", "dbo.Supervisors", "SupervisorId");
            DropColumn("dbo.Members", "Project_ProjectId");
            DropColumn("dbo.Members", "Enrollment_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Enrollment_ID", c => c.Int());
            AddColumn("dbo.Members", "Project_ProjectId", c => c.Int());
            DropForeignKey("dbo.Projects", "Supervisor_SupervisorId", "dbo.Supervisors");
            DropForeignKey("dbo.Enrollments", "Member_MemberId", "dbo.Members");
            DropIndex("dbo.Enrollments", new[] { "Member_MemberId" });
            DropIndex("dbo.Projects", new[] { "Supervisor_SupervisorId" });
            AlterColumn("dbo.Projects", "Supervisor_SupervisorId", c => c.Int(nullable: false));
            DropColumn("dbo.Enrollments", "Member_MemberId");
            DropColumn("dbo.Enrollments", "Member_ID");
            DropColumn("dbo.Projects", "Supervisor_ID");
            RenameColumn(table: "dbo.Projects", name: "Supervisor_SupervisorId", newName: "SupervisorId");
            CreateIndex("dbo.Members", "Enrollment_ID");
            CreateIndex("dbo.Members", "Project_ProjectId");
            CreateIndex("dbo.Projects", "SupervisorId");
            AddForeignKey("dbo.Projects", "SupervisorId", "dbo.Supervisors", "SupervisorId", cascadeDelete: true);
            AddForeignKey("dbo.Members", "Enrollment_ID", "dbo.Enrollments", "ID");
            AddForeignKey("dbo.Members", "Project_ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}
