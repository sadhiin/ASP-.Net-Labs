using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Contact{ get; set; }

        // One-to-many relationship with CollectRequest
        public  List<CollectRequest> CollectRequests { get; set; }

        // One-to-many relationship with DistributionRecord
        public List<DistributionRecord> DistributionRecords { get; set; }

        public Employee() 
        { 
            CollectRequests = new List<CollectRequest>();
            DistributionRecords = new List<DistributionRecord>();
        }
    }
}