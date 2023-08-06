using DLL.EF.Model;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class MemberRepo : Repo, IRepoMember<Project, bool, int>
    {
        public List<Project> Applied(int mid)
        {
            return _context.Members
                   .Where(m => m.MemberId == mid)
                   .SelectMany(m => m.Enrollments.Select(e => e.Project))
                   .ToList();

        }

        public bool ApplyEnrollment(int mid, int pid)
        {
            var member = _context.Members.SingleOrDefault(m => m.MemberId == mid);
            var project = _context.Projects.SingleOrDefault(p => p.ProjectId == pid);

            if (member == null || project == null)
            {
                // The member or project doesn't exist
                return false;
            }

            // Check if the member has already enrolled in the project
            var existingEnrollment = _context.Enrollments.SingleOrDefault(e => e.Member_ID == mid && e.ProjectId == pid);
            if (existingEnrollment != null)
            {
                // The member has already enrolled in the project
                return false;
            }

            var enrollment = new Enrollment { Member_ID = mid, ProjectId = pid};
            _context.Enrollments.Add(enrollment);
            int chk = _context.SaveChanges();

            return chk>0;
        }

        public List<Project> CompletedProject(int mid)
        {
            return _context.Enrollments
                   .Where(e => e.Member_ID == mid && e.Project.Status == 2)
                   .Select(e => e.Project)
                   .ToList();
        }

        public List<Project> OpenProjects()
        {
            return _context.Projects
                .Where(p => p.Status == 0)
                .ToList();
        }

        public List<Project> Projects(int mid)
        {
            throw new NotImplementedException();
        }
    }
}
