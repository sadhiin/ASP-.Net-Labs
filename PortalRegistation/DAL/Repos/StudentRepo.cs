using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentRepo : Repo, IRepoStudent<Course, int, bool, Registration, Enrollment>
    {
        public bool AddCouse(Course obj)
        {
            //_context.Students
            return false;
        }

        public bool ConfirmRegistration(int sid)
        {
            throw new NotImplementedException();
        }

        public List<Course> InCompleteCourses(int sid)
        {
            //var courses = _context.CoursesStudents
            //    .Where(cs => cs.StudentId == sid && cs.IsCompleted == false)
            //    .Select(cs => cs.Course)
            //    .ToList();

            return null;
        }

        public bool UpdateRegistrationStatus(int sid, int sem)
        {

            //var data = _context.Registrations.SingleOrDefault(r => r.Student_Id == sid);
            //if (data != null)
            //{
            //    data.RegistrationStatus = "pre-reg";
            //}
            return false; 
        }
    }
}
