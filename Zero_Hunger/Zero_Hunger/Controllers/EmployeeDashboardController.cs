using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class EmployeeDashboardController : Controller
    {
        private Zero_HungerDbContext _db;
        // GET: EmployeeDashboard
        [HttpGet]
        public ActionResult Index()
        {
            _db = new Zero_HungerDbContext();
            var requests = _db.CollectionRequests.Where(
                x => x.EmpId.Equals(
                    Int32.Parse(Session["id"].ToString())) && x.Status==1).ToList();

            return View(requests);
        }
    }
}