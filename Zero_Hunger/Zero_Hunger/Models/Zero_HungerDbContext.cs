using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Zero_Hunger.Models;

namespace Zero_Hunger.Models
{
    public class Zero_HungerDbContext: DbContext
    {
        public DbSet<NGO> NGOs{ get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<DistributionRecord> DistributionRecords { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the relationships between entities
            modelBuilder.Entity<NGO>()
                .HasMany(r => r.Employees);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.CollectRequests)
                .WithRequired(cr => cr.Restaurant)
                .HasForeignKey(cr => cr.RestaurantId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Collection)
                .WithOptional(cr => cr.Employee)
                .HasForeignKey(cr => cr.);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.DistributionRecords)
                .WithRequired(dr => dr.Employee)
                .HasForeignKey(dr => dr.EmployeeId);

            modelBuilder.Entity<CollectRequest>()
                .HasRequired(c => c.Restaurant)
                .WithMany()
                .HasForeignKey(c => c.RestaurantId)
                .WillCascadeOnDelete(false); // Specify ON DELETE NO ACTION

            base.OnModelCreating(modelBuilder);
        }
    }
}