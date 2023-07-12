using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Employee:User
    {

        //----------------Relations--------------------------

        public virtual ICollection<CollectRequest> Collections { get; set; }
        public virtual ICollection<DistributionRecord> DistributionRecords { get; set; }
        public Employee()
        {
            Collections = new List<CollectRequest>();
            DistributionRecords = new List<DistributionRecord>();
        }
    }
}
