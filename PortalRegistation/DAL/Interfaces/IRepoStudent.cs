using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IRepoStudent<MODELCLASS, NUMBER, LOGIC, RETURNCLASS, OTHERS>
    {
        List<MODELCLASS> InCompleteCourses(NUMBER sid);
        
        LOGIC AddCouse(NUMBER sid, MODELCLASS obj);

        LOGIC UpdateRegistrationStatus(NUMBER sid, NUMBER sem);
        LOGIC ConfirmRegistration(NUMBER sid);
    }
}
