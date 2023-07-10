using DEFirstNew.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEFirstNew.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBFirstEFEntities db = new DBFirstEFEntities();

            var dbData = db.students.ToList();
            return View(dbData);
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
    }
}