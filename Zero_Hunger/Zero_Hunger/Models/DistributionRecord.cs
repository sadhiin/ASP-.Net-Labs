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
        [Key]
        public int DistributionRecordId { get; set; }

        [Required(ErrorMessage ="Distribution date is required")]
        public DateTime DistributionDate { get; set; }

        [Required(ErrorMessage ="Distribution Location is required")]
        public string DistributionLocation { get; set; }


        [ForeignKey("CollectRequest")]
        public int CollectRequestId { get; set; }
        public CollectRequest CollectRequest { get; set; }

        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}