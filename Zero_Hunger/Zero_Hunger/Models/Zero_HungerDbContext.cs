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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Restaurant> Restaurants { get; set;}

        public DbSet<CollectionRequest> CollectionRequests { get; set; }

        public DbSet<Distribution> Distributions { get; set; }
    }
}
