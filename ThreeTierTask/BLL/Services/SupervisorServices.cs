using BLL.DTOs;
using DLL;
using DLL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SupervisorServices
    {

        public static bool CreateProject(int super_id, ProjectDTO obj)
        {
            var pjt = new Project();

            pjt.Title = obj.Title;
            pjt.Supervisor_ID = super_id;
            pjt.Status = 0;

            var rtn = DataAccessFactory.SupervisorDataAccess().CreateProject(pjt);
            return rtn;
        }

        public static bool ConfirmAproject( int pid)
        {
            var members = DataAccessFactory.SupervisorDataAccess().GetMembersInProject(pid);
            if (members == null || members.Count < 3)
            {
                return false;
            }

            var rtn = DataAccessFactory.SupervisorDataAccess().ConfirmProject(pid);

            return rtn;
        }

    }
}
