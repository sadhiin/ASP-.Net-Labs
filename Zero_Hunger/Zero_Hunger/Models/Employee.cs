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

        [ForeignKey("NGO")]
        public int NGOId { get; set; }
        public virtual NGO NGO { get; set; }

        [ForeignKey("Collection")]
        public int CollectionReuestId { get; set; }
        public virtual List<CollectRequest> Collection { get; set; }

    }
}