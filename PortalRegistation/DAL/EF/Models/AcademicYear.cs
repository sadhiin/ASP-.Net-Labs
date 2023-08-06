using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class AcademicYear
    {
        [Key]
        public int Id { get; set; }
        public string RegistrationStatus { get; set; } = "None";

        public int StudentId { get; set; }
        public int SemesterId { get; set; }

        public Student Student { get; set; }
        public Semester Semester { get; set; }
    }
}
