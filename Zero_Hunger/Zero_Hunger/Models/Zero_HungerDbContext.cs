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
        public DbSet<User> Users { get; set; }
        public DbSet<NGO> NGOs { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<DistributionRecord> Distributions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NGO>()
                .HasMany(n => n.Restaurants)
                .WithOptional()
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<NGO>()
                .HasMany(n => n.Employees)
                .WithOptional()
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.CollectionRequests)
                .WithRequired(cr => cr.Restaurant)
                .HasForeignKey(cr => cr.RestaurantId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Collections)
                .WithRequired(cr => cr.Employee)
                .HasForeignKey(cr => cr.CollectRequestId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.DistributionRecords)
                .WithRequired(d => d.Employee)
                .HasForeignKey(d => d.EmployeeID);

            modelBuilder.Entity<CollectRequest>()
                .HasOptional(cr => cr.DistributionRecord)
                .WithRequired(d => d.CollectRequest)
                .HasForeignKey(d => d.RequestID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
