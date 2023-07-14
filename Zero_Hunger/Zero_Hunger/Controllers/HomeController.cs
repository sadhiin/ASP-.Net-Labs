using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class HomeController : Controller
    {
        private Zero_HungerDbContext _db;
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
            if (Session["username"] != null)
            {
                return RedirectToAction("Index", "NGODashboard");
            }
            return View();
        }

        // POST: Home/NGOLogin
        [HttpPost]
        public ActionResult NGOLogin(NGO model)
        {
            if (ModelState.IsValid)
            {
                _db = new Zero_HungerDbContext();
                bool userExists = _db.NGOs.Any(
                    x => x.UserName.Equals(model.UserName) &&
                    x.Password.Equals(model.Password));

                if (userExists == true)
                {
                    NGO CurrentNGO = _db.NGOs.FirstOrDefault(
                        x => x.UserName.Equals(model.UserName) &&
                        x.Password.Equals(model.Password));

                    Session["username"] = CurrentNGO.UserName.ToString();

                    FormsAuthentication.SetAuthCookie(CurrentNGO.UserName, false);
                    return RedirectToAction("Index", "NGODashboard");
                }
                ModelState.AddModelError("", "Username or Password is wrong");
            }
            return View(model);
        }

        // GET: Home/RestaurantLogin
        [HttpGet]
        public ActionResult RestaurantLogin()
        {
            if (Session["username"]!=null)
            {
                return RedirectToAction("Index", "RestaurentDashboard");
            }
            return View();
        }

        // POST: Home/RestaurantLogin
        [HttpPost]
        public ActionResult RestaurantLogin(Restaurant model)
        {
            if (model.UserName.ToString() != null && model.Password.ToString() != null)
            { 
                _db = new Zero_HungerDbContext();

                bool restaurentExists = _db.Restaurants.Any(
                    x => x.UserName.Equals(model.UserName) &&
                    x.Password.Equals(model.Password));

                if (restaurentExists == true)
                {
                    Restaurant restaurant = _db.Restaurants.FirstOrDefault(
                        x => x.UserName.Equals(model.UserName) &&
                        x.Password.Equals(model.Password));

                    Session["id"] = restaurant.RestaurantID.ToString();
                    Session["username"] = restaurant.UserName.ToString();
                    Session["name"] = restaurant.RestaurantName.ToString();
                    FormsAuthentication.SetAuthCookie(restaurant.UserName, false);
                    return RedirectToAction("Index", "RestaurentDashboard");
                }
                ModelState.AddModelError("", "Username or Password is wrong");
            }
            return View();
        }

        // GET: Home/RestaurantSignup
        [HttpGet]
        public ActionResult RestaurantSignup()
        {
            return View();
        }

        // POST: Home/RestaurantSignup
        [HttpPost]
        public ActionResult RestaurantSignup(Restaurant model)
        {
            if(ModelState.IsValid) { 
                _db = new Zero_HungerDbContext();

                bool Exists = _db.Restaurants.Any(
                    x => x.UserName.Equals(model.UserName));
                if (Exists == true)
                {
                    ModelState.AddModelError("","User already exists. Try to login");
                    return View();
                }
                else
                {
                    model.NGOUsername = _db.NGOs.First().UserName.ToString();

                    _db.Restaurants.Add(model);
                    
                    _db.SaveChanges();

                    return RedirectToAction("RestaurantLogin");
                }
            }
            return View();
        }

        // GET: Home/EmployeeLogin
        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("Index", "EmployeeDashboard");
            }
            return View();
        }

        // POST: Home/EmployeeLogin
        [HttpPost]
        public ActionResult EmployeeLogin(Employee model)
        {
            if (model.UserName.ToString() != null && model.Password.ToString() != null)
            {
                _db = new Zero_HungerDbContext();
                bool EmployeeExists = _db.Employees.Any(
                    x => x.UserName.Equals(model.UserName) &&
                    x.Password.Equals(model.Password));
                if (EmployeeExists == true)
                {
                    Employee emp = _db.Employees.FirstOrDefault(
                        x => x.UserName.Equals(model.UserName) &&
                        x.Password.Equals(model.Password));

                    Session["id"] = emp.EmployeeId.ToString();
                    Session["username"] = emp.UserName.ToString();
                    Session["name"] = emp.Name.ToString();
                    FormsAuthentication.SetAuthCookie(emp.UserName, false);
                    return RedirectToAction("Index", "EmployeeDashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            }

            return View();
        }

        public ActionResult SignOut()
        {
            if (Session["username"] != null)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}