using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo: Repo, IAuth
    {
        public User Authenticate(string userid, string password)
        {
            var data = from u in _context.Users
                       where u.UserID.Equals(userid)
                       && u.Password.Equals(password)
                       select u;

            return data.SingleOrDefault();
        }
    }
}
