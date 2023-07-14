using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    [Authorize]
    public class NGODashboardController : Controller
    {
        private Zero_HungerDbContext _db;
        // GET: NGODashboard
        [HttpGet]
        public ActionResult Index()
        {
            _db = new Zero_HungerDbContext();

            var employees = _db.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                using (var _db = new Zero_HungerDbContext())
                {
                    model.NGOUsername = Session["username"].ToString();
                    _db.Employees.Add(model);
                    int chk = _db.SaveChanges();
                    if(chk > 0)
                    {
                        TempData["type"] = "ok";
                        TempData["success"] = "Employee Added";
                        TempData["info"] = "Added!";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["type"] = "error";
                        TempData["error"] = "Something went wrong";
                        TempData["info"] = "ERROR";
                        ModelState.Clear();
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEmp(int Id)
        {
            _db=new Zero_HungerDbContext();
            var emp = _db.Employees.FirstOrDefault(x=>x.EmployeeId.Equals(Id));
            return View(emp); 
        }
        [HttpPost]
        public ActionResult EditEmp(Employee model)
        {
            if (ModelState.IsValid)
            {
                _db = new Zero_HungerDbContext();
                _db.Entry(model).State= EntityState.Modified;
                int chk = _db.SaveChanges();
                if(chk > 0)
                {
                    TempData["type"] = "ok";
                    TempData["success"]= "Employee information updated!";
                    ModelState.Clear();
                }
                else
                {
                    TempData["error"]= "Something went wrong";
                    TempData["type"] = "error";
                    ModelState.Clear();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteEmp(int Id)
        {
            _db = new Zero_HungerDbContext();
            var emp = _db.Employees.FirstOrDefault(x => x.EmployeeId.Equals(Id));
            return View(emp);
        }
        [HttpPost]
        public ActionResult DeleteEmp(Employee model)
        {
            if (ModelState.IsValid)
            {
                _db = new Zero_HungerDbContext();
                _db.Entry(model).State = EntityState.Deleted;
                int chk = _db.SaveChanges();
                if(chk > 0)
                {
                    TempData["type"] = "ok";
                    TempData["success"] = "Employee deleted!";
                }
                else
                {
                    TempData["error"] = "Something went wrong";
                    TempData["type"] = "error";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Restaurants()
        {
            _db = new Zero_HungerDbContext();
            var restaurants = _db.Restaurants.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult RestDetails(int id)
        {
            _db = new Zero_HungerDbContext();
            var restaurant= _db.Restaurants.FirstOrDefault(x => x.RestaurantID.Equals(id));
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult RestDelete(int id)
        {
            _db = new Zero_HungerDbContext();
            var restaurent = _db.Restaurants.FirstOrDefault(x => x.RestaurantID.Equals(id));
            return View(restaurent);
        }
        [HttpPost]
        public ActionResult RestDelete(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                _db = new Zero_HungerDbContext();
                _db.Entry(model).State = EntityState.Deleted;
                int chk = _db.SaveChanges();
                if (chk > 0)
                {
                    TempData["type"] = "ok";
                    TempData["success"] = "Restaurant deleted!";
                }
                else
                {
                    TempData["error"] = "Something went wrong";
                    TempData["type"] = "error";
                }
            }
            return RedirectToAction("Restaurants");
        }

        [HttpGet]
        public ActionResult Requests() 
        {
            _db = new Zero_HungerDbContext();
            var requests = _db.CollectionRequests.ToList();
            return View(requests);
        }
    
        public ActionResult EditRequest(int id)
        {
            if (id != null)
            {
                _db = new Zero_HungerDbContext();
                var request = _db.CollectionRequests.FirstOrDefault(x=>x.CollectionRequestId.Equals(id));
                return View(request);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditRequest(CollectionRequest model)
        {
            if (ModelState.IsValid)
            {
                _db = new Zero_HungerDbContext();
                _db.Entry(model).State = EntityState.Modified; 
                int chk = _db.SaveChanges();
                if(chk > 0)
                {
                    TempData["type"] = "ok";
                    TempData["success"] = "Collection Updated!";
                }
                else
                {
                    TempData["error"] = "Something went wrong";
                    TempData["type"] = "error";
                }
            }
            return RedirectToAction("Requests");
        }
        [HttpGet]
        public ActionResult DeleteRequest(int id)
        {
            _db = new Zero_HungerDbContext();
            var request = _db.CollectionRequests.FirstOrDefault(x=>x.CollectionRequestId.Equals(id));
            return View(request);
        }
        [HttpPost]
        public ActionResult DeleteRequest(CollectionRequest model)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(model).State = EntityState.Deleted;
                int chk = _db.SaveChanges();
                if(chk > 0)
                {
                    TempData["type"] = "ok";
                    TempData["success"] = "Collection request deleted!";
                }
                else
                {
                    TempData["error"] = "Something went wrong";
                    TempData["type"] = "error";
                }
            }
            return RedirectToAction("Requests");
        }
        [HttpGet]
        public ActionResult RequestDetails(int id)
        {
            _db = new Zero_HungerDbContext();
            var request = _db.CollectionRequests.FirstOrDefault(x=>x.CollectionRequestId.Equals(id));
            return View(request);
        }
    }
}