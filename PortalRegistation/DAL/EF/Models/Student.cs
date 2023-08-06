using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }


        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Registration> Registrations { get; }
        public virtual ICollection<Semester> Semesters { get; set; }

        public Student() { 
            Enrollments = new List<Enrollment>();
            Registrations = new List<Registration>();
            Semesters = new List<Semester>();
        }
    }
}
