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

        public string Status { get; set; } // open, accepted, completed
    }
}