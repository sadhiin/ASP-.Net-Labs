using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Distribution
    {
        [Key]
        public int DistributionId { get; set; }

        [ForeignKey("Employee")] 
        public int EmployeeId { get; set; }
        [ForeignKey("CollectionRequest")]
        public int RequestId { get; set; }
        public DateTime DistributionTime { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual CollectionRequest CollectionRequest { get; set; }
    }
}