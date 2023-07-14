using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class NGO
    {
        [Key]
        [Required(ErrorMessage ="Username is required")]
        [Display(Name ="Username")]
        public string UserName { get; set; }
        [Display(Name ="Password")]
        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Restaurant>  Restaurants { get; set; }
        
        public NGO() 
        { 
            Employees = new List<Employee>();
            Restaurants = new List<Restaurant>();
        }
    }
}