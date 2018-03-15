using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            ViewBag.Controller = "Teachers";
            ViewBag.Method = "All Teachers";
            return View();
        }
        public ActionResult TeacherDetail()
        {
            ViewBag.Controller = "Teachers";
            ViewBag.Method = "Teacher Detail";
            return View();
        }
        public ActionResult AddTeacher()
        {
            ViewBag.Controller = "Teachers";
            ViewBag.Method = "Add Teacher";
            return View();
        }
    }
}