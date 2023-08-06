using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IRepoAdmin<CLASS, NUMBER, RNT, LOGIC, OTHER>
    {
        List<CLASS> GetAll();
        CLASS GetByID(NUMBER id);
        CLASS GetByName(OTHER name);
        LOGIC Create(CLASS obj); 
        LOGIC Delete(NUMBER id);
        LOGIC Update(CLASS obj); 
    }
}
