using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }

        public int Status { get; set; } = 0;
        // 0 -> Open
        // 1 -> In progress
        // 2 -> complete
        public int Supervisor_ID { get; set; }
    }
}
