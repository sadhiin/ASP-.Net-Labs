using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class DistributionRecord
    {
        
        [Required(ErrorMessage = "Distribution date is required")]
        public DateTime DistributionDate { get; set; }

        [Required(ErrorMessage = "Distribution Location is required")]
        public string DistributionLocation { get; set; }

        // ---------------Relations---------------------------

        [ForeignKey("NGO")]
        public int NGOId { get; set; }

        public virtual NGO NGO { get; set; }

        // Many-to-many relationship with Employee
        public virtual ICollection<Employee> Employees { get; set; }

        public int CollectRequestId { get; set; }

        [Key, ForeignKey("CollectRequestId")]
        public virtual CollectRequest CollectRequest { get; set; }

        public DistributionRecord()
        {
            Employees = new List<Employee>();
        }
    }
}
