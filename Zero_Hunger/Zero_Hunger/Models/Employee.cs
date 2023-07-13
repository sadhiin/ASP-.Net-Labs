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
        public string UserName { get; set; }
        public string Contract { get; set; }


        [ForeignKey("Request")]
        public int RequestId { get; set; }
        public CollectionRequest Request { get; set; }
        public virtual ICollection<CollectionRequest> CollectionRequests { get; set; }
        public virtual ICollection<Distribution> Distributions { get; set; }
    }
}