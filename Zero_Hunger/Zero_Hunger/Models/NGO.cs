using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class NGO:User
    {    

        //----------------Relations--------------------------

        // One-to-many relationship with Employee
        public virtual ICollection<Employee> Employees { get; set; }

        // One-to-many relationship with Restaurant
        public virtual ICollection<Restaurant> Restaurants { get; set; }


        public NGO()
        {
            Employees = new List<Employee>();
            Restaurants = new List<Restaurant>();
        }
    }
}
