using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "Dashboard";
            ViewBag.Method = "Admin";
            return View();
        }

        public ActionResult Student()
        {
            ViewBag.Controller = "Dashboard";
            ViewBag.Method = "Teachers";
            return View();
        }

        public ActionResult Parents()
        {
            ViewBag.Controller = "Dashboard";
            ViewBag.Method = "Parents";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Controller = "Teachers";
            ViewBag.Method = "All Teachers";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Controller = "Teachers";
            ViewBag.Method = "All Teachers";
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}