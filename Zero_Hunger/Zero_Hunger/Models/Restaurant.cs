using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9._]{2,19}$", ErrorMessage = "Invalid username. Only accept alphabets, numbers,'.' and'_'")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address. Formate example@example.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(32)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Address is required")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^01\d{9}$", ErrorMessage = "Invalid contract number. Followd by [01#########]")]
        public string Contract { get; set; }

        //----------------Relations--------------------------

        // Foreign key to NGO
        public int NGOId { get; set; }
        [ForeignKey("NGOId")]
        public virtual NGO NGO { get; set; }

        // One-to-many relationship with CollectionRecord
        public virtual ICollection<CollectRequest> CollectionRecords { get; set; }

        public Restaurant()
        {
            CollectionRecords = new List<CollectRequest>();
        }
    }
}