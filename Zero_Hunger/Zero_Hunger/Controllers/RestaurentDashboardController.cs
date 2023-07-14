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
            var requests = _db.CollectionRequests.Where(
                x => x.RestaurantId.Equals(
                    Int32.Parse(Session["id"].ToString()))).ToList();

            return View(requests);
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CollectionRequest request)
        {
            //had to add status and restaurent id
            //handle the employee for this.
            if(ModelState.IsValid)
            {
                request.Status = 0;
                request.RestaurantId = Int32.Parse(Session["id"].ToString());
                request.EmpId = 0;

                _db = new Zero_HungerDbContext();

                _db.CollectionRequests.Add(request);
                int chk = _db.SaveChanges();
                if (chk > 0)
                {
                    TempData["type"] = "ok";
                    TempData["success"] = "Request opened!";
                }
                else
                {
                    TempData["error"] = "Something went wrong";
                    TempData["type"] = "error";
                }
            }
            return RedirectToAction("Index");
        }
    }
}