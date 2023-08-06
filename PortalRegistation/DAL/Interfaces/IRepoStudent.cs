using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IRepoStudent<MODELCLASS, NUMBER, LOGIC, RETURNCLASS, OTHERS>
    {
        List<MODELCLASS> InCompleteCourses();

        LOGIC AddCouse(MODELCLASS obj);

        LOGIC UpdateRegistrationStatus(NUMBER sid, OTHERS regobj);
        LOGIC ConfirmRegistation(NUMBER sid);
    }
}
