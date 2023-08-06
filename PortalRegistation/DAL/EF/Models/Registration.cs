using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int Semester { get; set; }
        
        // 1 -> sp-23
        // 2-> sum -23
        // 3 -> Fall-23

        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }

        public string RegistrationStatus { get; set; } = "None";

        // O None 
        // 1 Pre-reg
        // 2 final confirmed
        // 3 dropped
        public virtual ICollection<Course> Courses{ get; set; }
        
        public Registration() { 
            Courses = new List<Course>();
        }   
    }
}
