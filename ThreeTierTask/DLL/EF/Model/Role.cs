using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int? RoleType { get; set; }
    }
}
