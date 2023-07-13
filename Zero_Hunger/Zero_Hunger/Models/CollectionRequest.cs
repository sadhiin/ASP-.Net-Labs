using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class CollectionRequest
    {
        [Key]
        public int CollectionRequestId { get; set; }

        [Required]
        public string CollectionRequestName { get; set; }

        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime MaxTimeToPreserve { get; set; }
        
        public string Status { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Distribution Distribution { get; set; }
    }
}