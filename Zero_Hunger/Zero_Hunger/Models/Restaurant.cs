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
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set;}
        public string UserName { get; set;}
        public string Password { get; set;}
        public string Location { get; set;}
        public string Contract { get; set;}

        public virtual ICollection<CollectionRequest> CollectionRequests { get; set;}   

        public Restaurant()
        {
            CollectionRequests = new List<CollectionRequest>();
        }
    }
}