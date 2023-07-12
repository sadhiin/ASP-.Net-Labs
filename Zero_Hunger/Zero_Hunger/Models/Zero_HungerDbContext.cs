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
            // NGO-Employee relationship
            modelBuilder.Entity<NGO>()
                .HasMany(e => e.Employees)                    // NGO has many Employees
                .WithRequired(e => e.NGO)                      // An Employee is required to have an NGO
                .HasForeignKey(e => e.NGOId);                   // Foreign key property in Employee class

            // NGO-Restaurant relationship
            modelBuilder.Entity<NGO>()
                .HasMany(r => r.Restaurants)                   // NGO has many Restaurants
                .WithRequired(r => r.NGO)                      // A Restaurant is required to have an NGO
                .HasForeignKey(r => r.NGOId);                   // Foreign key property in Restaurant class

            // NGO-CollectionRecord relationship
            modelBuilder.Entity<NGO>()
                .HasMany(c => c.CollectionRecords)             // NGO has many CollectionRecords
                .WithRequired(c => c.NGO)                       // A CollectionRecord is required to have an NGO
                .HasForeignKey(c => c.NGOId);                    // Foreign key property in CollectionRecord class

            // NGO-DistributionRecord relationship
            modelBuilder.Entity<NGO>()
                .HasMany(d => d.DistributionRecords)            // NGO has many DistributionRecords
                .WithRequired(d => d.NGO)                       // A DistributionRecord is required to have an NGO
                .HasForeignKey(d => d.NGOId);                    // Foreign key property in DistributionRecord class

            // Restaurant-CollectionRecord relationship
            modelBuilder.Entity<Restaurant>()
                .HasMany(c => c.CollectionRecords)             // Restaurant has many CollectionRecords
                .WithOptional(c => c.Restaurant)                // A CollectionRecord may or may not have a Restaurant
                .HasForeignKey(c => c.RestaurantId);             // Foreign key property in CollectionRecord class

            // Employee-CollectionRecord relationship
            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Collection)             // Employee has many CollectionRecords
                .WithOptional(c => c.Employee)                  // A CollectionRecord may or may not have an Employee
                .HasForeignKey(c => c.EmployeeId);               // Foreign key property in CollectionRecord class

            // CollectRequest-DistributionRecord relationship
            modelBuilder.Entity<CollectRequest>()
                .HasOptional(c => c.DistributionRecord)                    // A CollectRequest may or may not have a DistributionRecord
                .WithRequired(d => d.CollectRequest)                       // A DistributionRecord is required to have a CollectRequest
                .WillCascadeOnDelete(true);                                // Cascade delete 
        }
    }
}