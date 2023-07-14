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

        [Required(ErrorMessage ="Username is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        public string Contract { get; set; }

        [ForeignKey("ngo")]
        public string NGOUsername { get; set; }
        public NGO ngo { get; set; }

        public virtual ICollection<CollectionRequest> CollectionRequests { get; set; }
        public virtual ICollection<Distribution> Distributions { get; set; }

        public Employee() 
        { 
            CollectionRequests = new List<CollectionRequest>();
            Distributions = new List<Distribution>();
        }
    }
}