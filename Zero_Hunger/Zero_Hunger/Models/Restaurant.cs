using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Restaurant:User
    {
        //----------------Relations--------------------------

        // One-to-many relationship with CollectRequest
        public virtual ICollection<CollectRequest> CollectionRequests { get; set; }

        public Restaurant()
        {
            CollectionRequests = new List<CollectRequest>();
        }
    }
}
