using DLL.EF.Model;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class Member : Role, IRepoMember<Project, bool, int>
    {
        public List<Project> Applied(int mid)
        {
            throw new NotImplementedException();
        }

        public bool ApplyEnrollment(int pid)
        {
            throw new NotImplementedException();
        }

        public List<Project> CompletedProject(int mid)
        {
            throw new NotImplementedException();
        }

        public List<Project> OpenProjects()
        {
            throw new NotImplementedException();
        }

        public List<Project> Projects(int mid)
        {
            throw new NotImplementedException();
        }
    }
}
