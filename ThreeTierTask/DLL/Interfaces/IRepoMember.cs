using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IRepoMember<CLASS,LOGIC,NUMBER>
    {
        List<CLASS> OpenProjects();

        LOGIC ApplyEnrollment(NUMBER pid);

        List<CLASS> Applied(NUMBER mid);

        List<CLASS> CompletedProject(NUMBER mid);

        List<CLASS> Projects(NUMBER mid);
    }
}
