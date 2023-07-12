﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Restaurant 
    {
        [Key]
        public int RestaurantID { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9._]{2,19}$", ErrorMessage = "Invalid username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(32)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Contract number is required")]
        [RegularExpression(@"^01\d{9}$", ErrorMessage = "Invalid contract number")]
        public string Contract { get; set; }

        public string Address { get; set; }
        //----------------Relations--------------------------

        // One-to-many relationship with CollectRequest
        public virtual ICollection<CollectRequest> CollectionRequests { get; set; }

        public Restaurant()
        {
            CollectionRequests = new List<CollectRequest>();
        }
    }
}
