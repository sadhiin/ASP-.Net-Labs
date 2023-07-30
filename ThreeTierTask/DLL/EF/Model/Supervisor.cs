using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Model
{
    public class Supervisor
    {
        [Key]
        public int SupervisorId { get; set; }

        public string Name { get; set; }
        public IEnumerable<Project> Projects { get; set; }

        public Supervisor() { 
            Projects = new List<Project>();
        }
    }
}
