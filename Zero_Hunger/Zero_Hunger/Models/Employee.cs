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

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9._]{2,19}$", ErrorMessage = "Invalid username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(32)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Contract is required")]
        [RegularExpression(@"^01\d{9}$", ErrorMessage = "Invalid contract number. Followed by [01#########]")]
        public string Contract { get; set; }

        //----------------Relations--------------------------

        [ForeignKey("NGO")]
        public int NGOId { get; set; }

        public virtual NGO NGO { get; set; }

        public virtual ICollection<CollectRequest> Collections { get; set; }
        public virtual ICollection<DistributionRecord> DistributionRecords { get; set; }
        public Employee()
        {
            Collections = new List<CollectRequest>();
            DistributionRecords = new List<DistributionRecord>();
        }
    }
}
