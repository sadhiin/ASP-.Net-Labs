using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Model
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        
        public Member() {
            Enrollments = new List<Enrollment>();
        }

    }
}
