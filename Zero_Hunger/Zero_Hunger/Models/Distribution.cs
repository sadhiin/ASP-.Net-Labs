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

        public int? EmployeeId { get; set; }
        public int? CollectionRequestId { get; set; }

        public DateTime DistributionTime { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("CollectionRequestId")]
        public virtual CollectionRequest CollectionRequest { get; set; }
    }
}