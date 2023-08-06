using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int CourseStatus { get; set; }

        // 0=> None
        // 1=> Ongoing
        // 2=> dropped
        // 3=> completed

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Semester")]
        public int SemesterId { get; set; }


        public Semester Semester { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; } 
        

    }
}
