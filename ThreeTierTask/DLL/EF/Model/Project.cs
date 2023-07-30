using DLL.EF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Model
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Title { get; set; }

        public int Status { get; set; }
        // 0 -> Open
        // 1 -> In progress
        // 2 -> complete
        // Foreign key for supervisor
        public int Supervisor_ID { get; set; }
        public Supervisor Supervisor { get; set; }

        // Navigation property for enrollments in the project
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

