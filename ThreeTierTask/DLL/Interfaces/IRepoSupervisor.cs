using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IRepoSupervisor<CLASS, NUMBER,RTN, LOGIC>
    {
        LOGIC CreateProject(CLASS p);
        CLASS ProjectById(NUMBER id);
        List<CLASS> Projects();
        List<CLASS> OnGoingProjects();
        LOGIC ConfirmProject(NUMBER pId);
        LOGIC CompleteProject(NUMBER pId);
        List<CLASS> AllCompletedProjects();

        List<RTN> GetMembersInProject(NUMBER pId);
    }
}
