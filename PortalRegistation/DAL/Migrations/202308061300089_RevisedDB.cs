namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevisedDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationStatus = c.String(),
                        StudentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCompleted = c.Boolean(nullable: false),
                        CourseStatus = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        Registration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.Registration_Id)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.SemesterId)
                .Index(t => t.Registration_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StudentCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserID = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentSemesters",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Semester_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Semester_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.Semester_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Semester_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcademicYears", "StudentId", "dbo.Students");
            DropForeignKey("dbo.AcademicYears", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Students", "User_Id", "dbo.Users");
            DropForeignKey("dbo.StudentSemesters", "Semester_Id", "dbo.Semesters");
            DropForeignKey("dbo.StudentSemesters", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Registrations", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "Registration_Id", "dbo.Registrations");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentSemesters", new[] { "Semester_Id" });
            DropIndex("dbo.StudentSemesters", new[] { "Student_Id" });
            DropIndex("dbo.Registrations", new[] { "Student_Id" });
            DropIndex("dbo.Enrollments", new[] { "Registration_Id" });
            DropIndex("dbo.Enrollments", new[] { "SemesterId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "User_Id" });
            DropIndex("dbo.AcademicYears", new[] { "SemesterId" });
            DropIndex("dbo.AcademicYears", new[] { "StudentId" });
            DropTable("dbo.StudentSemesters");
            DropTable("dbo.Users");
            DropTable("dbo.Registrations");
            DropTable("dbo.Courses");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
            DropTable("dbo.AcademicYears");
        }
    }
}
