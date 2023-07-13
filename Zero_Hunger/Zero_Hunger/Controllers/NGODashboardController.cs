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
        public ActionResult Create(Employee model) 
        { 
            if(ModelState.IsValid)
            {
                try
                {
                    _db = new Zero_HungerDbContext();
                    _db.Employees.Add(model);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditEmp(int Id)
        {
            // have to implement the edit login
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmp(int Id)
        {
            // have to implement the delete logic
            return RedirectToAction("Index");
        }
    }
}