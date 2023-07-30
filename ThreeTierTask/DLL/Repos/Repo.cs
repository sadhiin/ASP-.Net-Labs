using DLL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class Repo
    {
        protected ProjectManagementContext _context;

        internal Repo()
        {
            _context = new ProjectManagementContext(); 
        }
    }
}
