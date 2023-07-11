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

        [ForeignKey("CollectRequest")]
        public int CollectRequestId { get; set; }
        public CollectRequest CollectRequest { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime DistributionDate { get; set; }

        public string DistributionLocation { get; set; }
    }
}