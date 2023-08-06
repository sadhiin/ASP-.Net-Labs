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
        public static IRepoSupervisor<Project, int, Member, bool> SupervisorDataAccess()
        {
            return new SupervisorRepo();
        }
        public static ICategory<Category, int, bool> CategoryDataAccess()
        {
            return new SupervisorRepo();
        }
        public static IRepoMember<Project, bool, int> MemberDataAccess()
        {
            return new MemberRepo();
        }
    }
}
