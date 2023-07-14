using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class RestaurentDashboardController : Controller
    {
        private Zero_HungerDbContext _db;
        // GET: RestaurentDashboard
        public ActionResult Index()
        {
            _db = new Zero_HungerDbContext();
            var restid = Convert.ToInt32(Session["ID"].ToString());
            var requests = _db.CollectionRequests.Where(
                x => x.RestaurantId.Equals(restid)).ToList();
            if (requests.Count > 0)
                return View(requests);
            else
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
                request.EmpId = 0;

                _db = new Zero_HungerDbContext();
                request.CreationDate = DateTime.Parse(request.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
                request.MaxTimeToPreserve = DateTime.Parse(request.MaxTimeToPreserve.ToString("yyyy-MM-dd HH:mm:ss"));
                
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