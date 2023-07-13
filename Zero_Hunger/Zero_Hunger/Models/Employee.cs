using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Contract { get; set; }


        public virtual ICollection<CollectionRequest> CollectionRequests { get; set; }
        public virtual ICollection<Distribution> Distributions { get; set; }

        public Employee() 
        { 
            CollectionRequests = new List<CollectionRequest>();
            Distributions = new List<Distribution>();
        }
    }
}