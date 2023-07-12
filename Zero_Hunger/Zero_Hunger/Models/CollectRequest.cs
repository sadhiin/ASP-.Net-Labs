using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class CollectRequest
    {
        [Key]
        public int CollectRequestId { get; set; }

        [Required(ErrorMessage = "Maximum preservation time is required")]
        public DateTime MaximumPreservationTime { get; set; }

        public int Status { get; set; } // 0: open, 1: accepted, 2: completed

        //-------------Relation-------------------

        // Foreign key to NGO
        //[ForeignKey("NGO")]
        //public int NGOId { get; set; }

        //public virtual NGO NGO { get; set; }

        //public int EmployeeId { get; set; }

        //[ForeignKey("EmployeeId")]
        //public virtual Employee Employee { get; set; }

        //public int RestaurantId { get; set; }

        //[ForeignKey("RestaurantId")]
        //public virtual Restaurant Restaurant { get; set; }

        //// One-to-one relationship with DistributionRecord
        //public virtual DistributionRecord DistributionRecord { get; set; }
    }
}
