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

            List<string> companyImages = new List<string>();
            int pno = 0;
            //int cno = 0;
            foreach (string image in allimages)
            {
                string p = "project";
                string c = "company";
                if (image.Contains(p))
                {
                    Project classProject = new Project();

                    classProject.ProjectName = "Project - " + pno.ToString();
                    pno++;
                    classProject.PorjectImage = image;
                    classProject.ProjectDetails = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.";
                    projects.Add(classProject);
                }
                else if(image.Contains(c))
                {
                    companyImages.Add(image);
                }
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