using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    [Authorize]
    public class RestaurentDashboardController : Controller
    {
        private Zero_HungerDbContext _db;
        // GET: RestaurentDashboard
        public ActionResult Index()
        {
                _db = new Zero_HungerDbContext();
            ////_db.Database.ExecuteSqlCommand("ALTER TABLE CollectionRequests ADD CollectionRequestId int IDENTITY(1,1) PRIMARY KEY");
            //_db.Database.ExecuteSqlCommand("ALTER TABLE CollectionRequests DROP COLUMN CollectionRequestId");
            //_db.Database.ExecuteSqlCommand("ALTER TABLE CollectionRequests ADD CollectionRequestId int IDENTITY(1,1) PRIMARY KEY");

            var restid = Convert.ToInt32(Session["ID"].ToString());
            var requests = _db.CollectionRequests.Where(
                x => x.RestaurantId.Equals(restid)).ToList();
            if (requests.Count > 0)
                return View(requests);
            
            return View();
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CollectionRequest request)
        {
            if(ModelState.IsValid)
            {
                request.Status = 0;
                request.RestaurantId = Convert.ToInt32(Session["id"].ToString());
                request.EmpId = 1;

                _db = new Zero_HungerDbContext();
                
                request.Distribution = null;
                _db.CollectionRequests.Add(request);
                int chk = _db.SaveChanges();
                if (chk > 0)
                {
                    TempData["type"] = "ok";
                    TempData["msg"] = "Request opened!";
                    TempData["info"] = "Added";
                }
                else
                {
                    TempData["type"] = "error";
                    TempData["msg"] = "Something went wrong";
                    TempData["info"] = "Error";
                }
            }
            return RedirectToAction("Index");
        }
    }
}