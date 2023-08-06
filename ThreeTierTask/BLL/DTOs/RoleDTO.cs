using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int? RoleType { get; set; } = 2;
    }
}
