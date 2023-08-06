﻿using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Token, int, Token, string> TokenDataAccess()
        {
            return new TokenRepo();
        }
    }
}
