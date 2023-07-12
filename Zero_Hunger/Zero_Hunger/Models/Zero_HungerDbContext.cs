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
        public DbSet<NGO> NGOs { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<DistributionRecord> DistributionRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the one-to-one relationship between CollectRequest and DistributionRecord
            modelBuilder.Entity<CollectRequest>()
                .HasOptional(c => c.DistributionRecord)
                .WithRequired(d => d.CollectionRequest)
                .Map(m => m.MapKey("CollectRequestId"))
                .WillCascadeOnDelete(true);

            // Configure the other relationships as before

            // NGO-Employee relationship
            modelBuilder.Entity<NGO>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.NGO)
                .HasForeignKey(e => e.NGOId);

            // NGO-Restaurant relationship
            modelBuilder.Entity<NGO>()
                .HasMany(r => r.Restaurants)
                .WithRequired(r => r.NGO)
                .HasForeignKey(r => r.NGOId);

            // NGO-CollectionRecord relationship
            modelBuilder.Entity<NGO>()
                .HasMany(c => c.CollectionRecords)
                .WithRequired(c => c.NGO)
                .HasForeignKey(c => c.NGOId);

            // NGO-DistributionRecord relationship
            modelBuilder.Entity<NGO>()
                .HasMany(d => d.DistributionRecords)
                .WithRequired(d => d.NGO)
                .HasForeignKey(d => d.NGOId);

            // Restaurant-CollectionRecord relationship
            modelBuilder.Entity<Restaurant>()
                .HasMany(c => c.CollectionRecords)
                .WithOptional(c => c.Restaurant)
                .HasForeignKey(c => c.RestaurantId)
                .WillCascadeOnDelete(false);

            // Employee-CollectionRecord relationship
            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Collection)
                .WithOptional(c => c.Employee)
                .HasForeignKey(c => c.EmployeeId);

            // CollectRequest-DistributionRecord relationship is already configured above
        }
    }
}