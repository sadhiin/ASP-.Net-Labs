using Lab_Task_1_CV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_Task_1_CV.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        public ActionResult Index()
        {
            var e1 = new Education() { Level = "BSC", ins ="American International Univeristy-Bangladesh", passingYear="2023"};
            var e2 = new Education() { Level = "HSC", ins = "BAF Shaheen Collage Dhaka", passingYear = "2018" };
            var e3 = new Education() { Level = "SSC", ins = "Rowshidpur M.L. High School, Gurudshpur Natore", passingYear = "2016" };
            Education[] edu = new Education[] {e1, e2, e3}; 
            return View(edu);
        }
    }
}