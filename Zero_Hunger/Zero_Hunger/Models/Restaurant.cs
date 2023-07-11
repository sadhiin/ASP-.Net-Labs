using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact{ get; set; }

        // One-to-many relationship with CollectRequest
        public virtual List<CollectRequest> CollectRequests { get; set; }

        public Restaurant()
        {
            CollectRequests = new List<CollectRequest>();
        }
    }
}