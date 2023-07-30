using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Model
{
    public class Enrollment
    {
        [Key]
        public int ID{ get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        // Foreign key for member
        public int Member_ID { get; set; }
        public Member Member { get; set; }
    }
}
