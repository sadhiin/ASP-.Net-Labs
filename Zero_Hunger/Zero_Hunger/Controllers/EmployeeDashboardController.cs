using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    [Authorize]
    public class EmployeeDashboardController : Controller
    {
        private Zero_HungerDbContext _db;
        // GET: EmployeeDashboard
        [HttpGet]
        public ActionResult Index()
        {
            var employeeId = Convert.ToInt32(Session["id"].ToString());
            _db = new Zero_HungerDbContext();
            var requests = _db.CollectionRequests
                .Where(x => x.EmpId == employeeId && x.Status == 1)
                .ToList();

            if (requests.Count > 0)
            {
                return View(requests);
            }
            else
                return View();
        }
    }
}