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

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required(ErrorMessage ="Maximum preserve time is required")]
        public DateTime MaximumPreservationTime { get; set; }

        public int Status { get; set; } // 0: open, 1: accepted, 2: completed

        [ForeignKey("Resturent")]
        public int ResturentId { get; set; }
        public virtual Restaurant Resturent { get; set; }

        [ForeignKey("Emp")]
        public int EmpId { get; set; }
        public virtual Employee Emp { get; set;}
    }
}