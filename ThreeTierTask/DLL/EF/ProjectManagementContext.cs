using DLL.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF
{
    public class ProjectManagementContext : DbContext
    {
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Define the relationships between entities
        //    modelBuilder.Entity<Project>()
        //        .HasRequired(p => p.Supervisor)
        //        .WithMany(s => s.Projects)
        //        .HasForeignKey(p => p.Supervisor_ID);

        //    modelBuilder.Entity<Enrollment>()
        //        .HasRequired(e => e.Member)
        //        .WithMany(m => m.Enrollments)
        //        .HasForeignKey(e => e.Member_ID);

        //    modelBuilder.Entity<Enrollment>()
        //        .HasRequired(e => e.Project)
        //        .WithMany(p => p.Enrollments)
        //        .HasForeignKey(e => e.ProjectId);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
