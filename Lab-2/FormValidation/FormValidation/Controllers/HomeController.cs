using FormValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace FormValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

        // GET: Home
        [HttpGet]
        public ActionResult Login()
        {
            //ViewBag.Name = Request["Username"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            ViewBag.Name = Username;
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User u)
        {

            //var test = u.Dob.Date.ToString("yyyy-MM-dd");

            if (ModelState.IsValid)
            {
                var age = DateTime.Now.Year - u.Dob.Year;
                if (u.Dob > DateTime.Now.AddYears(-age)) age--;

                if (age < 20)
                {
                    ModelState.AddModelError("Dob", "You must be at least 20 years old.");
                    return View(u);
                }
                else
                {
                    // Save the user to the database or do other actions...
                    return RedirectToAction("Login");
                }
            }
            return View(u);
        }
    }
}