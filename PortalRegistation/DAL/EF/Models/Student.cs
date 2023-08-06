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

        //student registation status

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Registration> Registrations { get; }
    }
}
