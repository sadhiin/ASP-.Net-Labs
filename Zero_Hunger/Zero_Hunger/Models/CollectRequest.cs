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

        [Required(ErrorMessage ="Status is required")]
        public int Status { get; set; } // 0: open, 1: accepted, 2: completed

        //-------------Relationships-------------------


        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        //// One-to-one relationship with DistributionRecord
        public virtual DistributionRecord DistributionRecord { get; set; }
    }
}
