using Compnay_Landing_Page.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compnay_Landing_Page.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // here wel will add images 
            String path = Server.MapPath("~/App_Data/images/");
            List<string> allimages = new List<string>(Directory.GetFiles(path));

            List<Project> projects = new List<Project>();

            List<string> companyImages = new List<string>() { "https://source.unsplash.com/hCb3lIB8L8E", "https://source.unsplash.com/AQTA5E6mCNU", "https://source.unsplash.com/U2BI3GMnSSE"};
            int pno = 0;
            List<string> imageids = new List<string>() { "FMArg2k3qOU", "4F-gV7FoFZo", "hpjSkU2UYSU", "EnyWf7q_uxc", "iar-afB0QQw", "M5tzZtFCOfs" };
            for(int i=0; i<5; i++)
            {
               
                    Project classProject = new Project();

                    classProject.ProjectName = "Project - " + pno.ToString();
                    pno++;
                    classProject.PorjectImage = "https://source.unsplash.com/" + imageids[i];
                    classProject.ProjectDetails = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.";
                    projects.Add(classProject);
            
            }

            ViewBag.CompanyImages = companyImages;
            ViewBag.Projects = projects;

            return View();
        }

        public ActionResult Services()
        {
            return View();
        }
        
        public ActionResult Teams()
        {
            string[] maleNames = new string[] { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };
            string[] femaleNames = new string[] { "abby", "abigail", "adele", "adrian" };
            string[] lastNames = new string[] { "abbott", "acosta", "adams", "adkins", "aguilar" };
            string firstName = "";
            Random rand = new Random(DateTime.Now.Second);
            if (rand.Next(1, 3) == 1)
            {
                firstName = maleNames[rand.Next(0, maleNames.Length)];
            }
            else
            {
                firstName = femaleNames[rand.Next(0, femaleNames.Length)];
            }
            string lst = lastNames[rand.Next(0, lastNames.Length)];

            List<string> imagesIds = new List<string>() {"6anudmpILw4", "KIPqvvTOC1s", "DItYlc26zVI", "RiDxDgHg7pw" , "WC7KIHo13Fc" };
            List<Member> members = new List<Member>();
            //public int Id { get; set; }
            //public string Position { get; set; }
            //public string Name { get; set; }
            //public string Email { get; set; }
            //public string Phone { get; set; }
            //public string Description
            int id = 0;
            string loremtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Viverra justo nec ultrices dui sapien eget mi.";
            string[] positions = new string[] {
                            "Software Engineer",
                            "Data Scientist",
                            "Product Manager",
                            "UX/UI Designer",
                            "DevOps Engineer",
                            "Quality Assurance Engineer",
                            "Systems Analyst",
                            "Database Administrator",
                            "Network Administrator",
                            "Cybersecurity Analyst",
                            "IT Support Specialist",
                            "Business Analyst",
                            "Scrum Master",
                            "Technical Writer",
                            "IT Project Manager"
             };

            foreach (string imageid in imagesIds)
            {
                Member m = new Member() {
                    Name = firstName + " " + lst,
                    personImage = "https://source.unsplash.com/" + imageid,
                    Position = positions[rand.Next(0, positions.Length)],
                    Email = lst + "@mail.com", Phone = "0399938383", 
                    Id = id++, Description =loremtext 
                };
                members.Add(m);
            }

            ViewBag.Members = members;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}