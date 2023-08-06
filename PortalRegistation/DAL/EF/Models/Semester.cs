using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string SemesterName { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Semester() { 
            Students = new List<Student>();
        }
    }
}
