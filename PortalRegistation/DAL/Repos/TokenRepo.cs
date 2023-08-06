using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, int, Token, string>
    {
        public Token Create(Token obj)
        {
            _context.Tokens.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public Token Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Token> GetAll()
        {
            return _context.Tokens.ToList();
        }

        public Token GetByID(int id)
        {
            return _context.Tokens.Find(id);
        }

        public Token GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Token Update(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}
