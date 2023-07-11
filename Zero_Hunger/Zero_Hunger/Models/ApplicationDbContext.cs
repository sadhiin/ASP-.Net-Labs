using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<DistributionRecord> DistributionRecords { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the relationships between entities
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.CollectRequests)
                .WithRequired(cr => cr.Restaurant)
                .HasForeignKey(cr => cr.RestaurantId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CollectRequests)
                .WithOptional(cr => cr.Employee)
                .HasForeignKey(cr => cr.EmployeeId);

            //modelBuilder.Entity<Employee>()
            //    .HasMany(e => e.DistributionRecords)
            //    .WithRequired(dr => dr.Employee)
            //    .HasForeignKey(dr => dr.EmployeeId);

            //modelBuilder.Entity<CollectRequest>()
            //    .HasOptional(cr => cr.CollectRequestId)
            //    .WithRequired(dr => dr.CollectRequest)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}