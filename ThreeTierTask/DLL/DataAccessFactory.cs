using DLL.EF.Model;
using DLL.Interfaces;
using DLL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class DataAccessFactory
    {
        public static IRepoSupervisor<Project> SupervisorDataAccess()
        {
            return new SupervisorRepo();
        }
    }
}
