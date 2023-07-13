using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index()
        {
            _db = new Zero_HungerDbContext();

            var employees = _db.Employees.ToList();
            return View(employees);
        }

        [HttpPost]
        public ActionResult Create(Employee model) { 

            return View();
        }
    }
}