using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormValidation.Models
{
    public class User
    {

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3    )]
        [RegularExpression(@"^[a-zA-Z\s\.]*$", ErrorMessage = "Only alphabets, spaces, and dots are allowed in the name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter your username.")]
        [StringLength(15, ErrorMessage = "The {0} must be at most {1} characters long.")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "Only alphabets, numbers, and underscores are allowed.")]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required]
        public string Gender { get; set; }


        [Required]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        //[MinimumAge(20, ErrorMessage = "You must be at least 20 years old.")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Please enter your student ID.")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Invalid student ID. Format: xx-xxxxx-x where x is a digit and the last digit is between 1 and 3.")]
        [Display(Name = "Student ID")]
        public string Student_Id { get; set; }


        [Required(ErrorMessage = "Please enter your email.")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$", ErrorMessage = "Invalid Email Address. Format: xx-xxxxx-x@student.aiub.edu")]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}