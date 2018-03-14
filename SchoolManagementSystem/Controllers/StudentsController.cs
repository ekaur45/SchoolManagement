using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        
        public ActionResult Index()
        {
            ViewBag.Controller = "Students";
            ViewBag.Method = "All Students";
            return View();
        }
        public ActionResult StudentDetail()
        {
            ViewBag.Controller = "Students";
            ViewBag.Method = "Student Detail";
            return View();
        }
        public ActionResult Form()
        {
            ViewBag.Controller = "Students";
            ViewBag.Method = "Admission Form";
            return View();
        }
    }
}