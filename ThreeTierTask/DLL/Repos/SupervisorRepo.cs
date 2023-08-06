using DLL.EF;
using DLL.EF.Model;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class SupervisorRepo : Repo, IRepoSupervisor<Project, int, Member, bool>, ICategory<Category, int, bool>
    {
        public List<Project> AllCompletedProjects()
        {
            return _context.Projects.Where(p => p.Status == 2).ToList();
        }

        public Project ProjectById(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.ProjectId == id);
        }
        public bool CompleteProject(int pId)
        {
            // corresponding checking will in BLL
            var projectInDb = _context.Projects.Find(pId);
            projectInDb.Status = 2;
            return _context.SaveChanges() > 0;
        }

        public bool ConfirmProject(int pId)
        {
            // relative checking and condingtion will be on BLL
            var projectInDb = _context.Projects.Find(pId);
            projectInDb.Status = 1;
            return _context.SaveChanges() > 0;
        }

        public bool CreateProject(Project p)
        {
            _context.Projects.Add(p);
            return _context.SaveChanges() > 0;
        }

        public List<Project> OnGoingProjects()
        {
            return _context.Projects.Where(p=>p.Status == 1).ToList();
        }

        public List<Project> Projects()
        {
            return _context.Projects.Where(p=>p.Status==0).ToList();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public bool Create(Category category)
        {
            _context.Categories.Add(category);
            int chk = _context.SaveChanges();
            return chk > 0;
        }

        public Category GetCategory(int cid)
        {
            return _context.Categories.Find(cid);
        }

        public List<Member> GetMembersInProject(int pId)
        {
            return _context.Projects
                   .Where(p => p.ProjectId == pId)
                   .SelectMany(p => p.Enrollments.Select(e => e.Member))
                   .ToList();
        }
    }
}
