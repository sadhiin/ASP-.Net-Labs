using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API_Assignemnt.Models
{

    public class AssignmentContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> Newses{ get; set; }
    }
}