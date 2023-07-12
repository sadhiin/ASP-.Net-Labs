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

        [Required(ErrorMessage ="Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage ="Contract is required")]
        [RegularExpression(@"^01\d{9}$", ErrorMessage = "Invalid contract number. Followed by [01#########]")]
        public string Contract { get; set; }

        //----------------Relations--------------------------


        public int NGOId { get; set; }

        [ForeignKey("NGOId")]
        public virtual NGO NGO { get; set; }

        public virtual ICollection<CollectRequest> Collection { get; set; }

        public Employee()
        {
            Collection = new List<CollectRequest>();
        }
    }
}