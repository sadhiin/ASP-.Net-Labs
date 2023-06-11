using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_Task_1_CV.Models;

namespace Lab_Task_1_CV.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            Project project = new Project { Id=0,CourseName="Web-Tech",Name="On-The-Go podcast",gitLink="www.github.com/sadhiin"};
            Project project_1 = new Project { Id = 1, CourseName = "CVPR", Name = "Face-Maks Detection", gitLink = "www.github.com/sadhiin" };
            Project project_2 = new Project { Id = 2, CourseName = "ML", Name = "Fasion-Recomendation", gitLink = "www.github.com/sadhiin" };
            Project project_3 = new Project { Id = 3,CourseName = "Javascript", Name = "Basic DOM", gitLink = "www.github.com/sadhiin" };
            Project project_4 = new Project { Id = 4, CourseName = "OOP-2", Name = "Hospital Management System", gitLink = "www.github.com/sadhiin" };
            Project project_5 = new Project { Id = 5, CourseName = "OOP-1", Name = "Calculator", gitLink = "www.github.com/sadhiin" };
            Project project_6 = new Project { Id = 6, CourseName = "IPL", Name = "Cosole VUEs", gitLink = "www.github.com/sadhiin" };

           IList<Project> projectList = new List<Project>() { project_1, project_2, project_3, project_4, project_5, project_6 };

            ViewBag.ProjectList = projectList;
            return View(project);
        }
    }
}