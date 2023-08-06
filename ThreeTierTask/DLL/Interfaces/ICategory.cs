﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface ICategory<CLASS, NUMBER, LOGIC>
    {
        List<CLASS> GetCategories();
        LOGIC Create(CLASS category);

        CLASS GetCategory(NUMBER cid);
    }
}
