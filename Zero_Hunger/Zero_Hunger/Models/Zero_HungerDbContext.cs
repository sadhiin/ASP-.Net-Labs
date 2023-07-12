using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using Zero_Hunger.Models;

namespace Zero_Hunger.Models
{
    public class Zero_HungerDbContext : DbContext
    {
        public DbSet<NGO> NGOs { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<DistributionRecord> DistributionRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectRequest>()
                .HasOptional(cr => cr.DistributionRecord)
                .WithRequired(dr => dr.CollectRequest);

            // Configure the relationships

            // NGO - Employee (One-to-Many)
            //modelBuilder.Entity<Employee>()
            //    .HasRequired(e => e.NGO)
            //    .WithMany(n => n.Employees)
            //    .HasForeignKey(e => e.NGOId);

            //// NGO - Restaurant (One-to-Many)
            //modelBuilder.Entity<Restaurant>()
            //    .HasRequired(r => r.NGO)
            //    .WithMany(n => n.Restaurants)
            //    .HasForeignKey(r => r.NGOId);

            //// NGO - CollectRequest (One-to-Many)
            //modelBuilder.Entity<CollectRequest>()
            //    .HasRequired(cr => cr.NGO)
            //    .WithMany(n => n.CollectionRequests)
            //    .HasForeignKey(cr => cr.NGOId);

            //// NGO - DistributionRecord (One-to-Many)
            //modelBuilder.Entity<DistributionRecord>()
            //    .HasRequired(dr => dr.NGO)
            //    .WithMany(n => n.DistributionRecords)
            //    .HasForeignKey(dr => dr.NGOId);

            //// Restaurant - CollectRequest (One-to-Many)
            //modelBuilder.Entity<CollectRequest>()
            //    .HasRequired(cr => cr.Restaurant)
            //    .WithMany(r => r.CollectionRequests)
            //    .HasForeignKey(cr => cr.RestaurantId);

            //// Employee - CollectRequest (One-to-Many)
            //modelBuilder.Entity<CollectRequest>()
            //    .HasRequired(cr => cr.Employee)
            //    .WithMany(e => e.Collections)
            //    .HasForeignKey(cr => cr.EmployeeId);

            //// CollectRequest - DistributionRecord (One-to-One)
            //modelBuilder.Entity<DistributionRecord>()
            //    .HasRequired(dr => dr.CollectRequest)
            //    .WithOptional(cr => cr.DistributionRecord);

            // CollectRequest - DistributionRecord (One-to-Many)
            //modelBuilder.Entity<DistributionRecord>()
            //    .HasRequired(dr => dr.CollectRequest)
            //    .WithOptional(cr => cr.DistributionRecord)
            //    .HasForeignKey(dr => dr.CollectRequest);

            // DistributionRecord - Employee (Many-to-Many)
            //modelBuilder.Entity<DistributionRecord>()
            //    .HasMany(dr => dr.Employees)
            //    .WithMany(e => e.DistributionRecords)
            //    .Map(m =>
            //    {
            //        m.ToTable("DistributionRecordEmployees");
            //        m.MapLeftKey("DistributionRecordId");
            //        m.MapRightKey("EmployeeId");
            //    });
        }
    }
}
