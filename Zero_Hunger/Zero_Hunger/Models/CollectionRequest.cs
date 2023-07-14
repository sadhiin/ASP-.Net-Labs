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

        public int Status { get; set; }

        public int RestaurantId { get; set; }
        public int? EmpId { get; set; }

        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }

        public virtual Distribution Distribution { get; set; }
    }
}