using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }


        // O None 
        // 1 Pre-reg
        // 2 final confirmed
        // 3 dropped
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Registration()
        {
            Enrollments = new List<Enrollment>();
        }
    }
}
