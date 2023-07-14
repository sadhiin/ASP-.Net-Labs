using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Restaurant
    {
        private const string V = "Your Restaurant Name Can't be Empty";

        [Key]
        public int RestaurantID { get; set; }
        [Required(ErrorMessage = V)]
        public string RestaurantName { get; set;}
        
        [Required(ErrorMessage ="Username is required")]
        [Display(Name = "Username")]
        public string UserName { get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set;}

        [Required]
        public string Location { get; set;}

        [Required]
        public string Contract { get; set;}

        [ForeignKey("ngo")]
        public string NGOUsername { get; set;}
        public NGO ngo { get; set;}
        public virtual ICollection<CollectionRequest> CollectionRequests { get; set;}   

        public Restaurant()
        {
            CollectionRequests = new List<CollectionRequest>();
        }
    }
}