using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class HomeController : Controller
    {
        [Route("About")]
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

        // GET: Home/NGOLogin
        [HttpGet]
        public ActionResult NGOLogin()
        {
            return View();
        }

        // POST: Home/NGOLogin
        [HttpPost]
        public ActionResult NGOLogin(NGO model)
        {
            if (ModelState.IsValid)
            {
                // Perform NGO login logic here
                // Check the provided credentials and redirect to appropriate page
                // Example: if (ValidNGOCredentials(model.UserName, model.Password))
                //           {
                //               return RedirectToAction("Dashboard", "NGO");
                //           }
                //           else
                //           {
                //               ModelState.AddModelError("", "Invalid credentials.");
                //           }
            }

            return View(model);
        }

        // GET: Home/RestaurantLogin
        public ActionResult RestaurantLogin()
        {
            return View();
        }

        // POST: Home/RestaurantLogin
        [HttpPost]
        public ActionResult RestaurantLogin(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                // Perform restaurant login logic here
                // Check the provided credentials and redirect to appropriate page
                // Example: if (ValidRestaurantCredentials(model.UserName, model.Password))
                //           {
                //               return RedirectToAction("Dashboard", "Restaurant");
                //           }
                //           else
                //           {
                //               ModelState.AddModelError("", "Invalid credentials.");
                //           }
            }

            return View(model);
        }

        // GET: Home/RestaurantSignup
        public ActionResult RestaurantSignup()
        {
            return View();
        }

        // POST: Home/RestaurantSignup
        [HttpPost]
        public ActionResult RestaurantSignup(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                // Perform restaurant signup logic here
                // Create a new Restaurant object and save it to the database
                // Example: Restaurant restaurant = new Restaurant { RestaurantName = model.RestaurantName, UserName = model.UserName, Password = model.Password, Location = model.Location, Contract = model.Contract };
                //           SaveRestaurant(restaurant);
                //           return RedirectToAction("RestaurantLogin");
            }

            return View(model);
        }

        // GET: Home/EmployeeLogin
        public ActionResult EmployeeLogin()
        {
            return View();
        }

        // POST: Home/EmployeeLogin
        [HttpPost]
        public ActionResult EmployeeLogin(Employee model)
        {
            if (ModelState.IsValid)
            {
                // Perform employee login logic here
                // Check the provided credentials and redirect to appropriate page
                // Example: if (ValidEmployeeCredentials(model.UserName, model.Password))
                //           {
                //               return RedirectToAction("Dashboard", "Employee");
                //           }
                //           else
                //           {
                //               ModelState.AddModelError("", "Invalid credentials.");
                //           }
            }

            return View(model);
        }
    }
}