using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class RestaurentDashboardController : Controller
    {
        // GET: RestaurentDashboard
        public ActionResult Index()
        {
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

            return View(request);
        }
    }
}