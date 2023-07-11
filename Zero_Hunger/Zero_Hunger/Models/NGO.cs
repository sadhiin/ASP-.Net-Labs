using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class NGO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [ForeignKey(Employees)]
        public int EmployeeId { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public virtual List<Restaurant> Restaurants { get; set; }
        public NGO() 
        { 
            Employees = new List<Employee>();
            Restaurants = new List<Restaurant>();
        }

    }
}