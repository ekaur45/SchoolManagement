using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            ViewBag.Controller = "Classes";
            ViewBag.Method = "All Classes";
            return View();
        }
        public ActionResult NewClass()
        {
            ViewBag.Controller = "Classes";
            ViewBag.Method = "New Class";
            return View();
        }
        public ActionResult TimeTable()
        {
            ViewBag.Controller = "Classes";
            ViewBag.Method = "Time Table";
            return View();
        }
        public void SaveTimeTable(SchoolManagementSystem.Models.tbl table)
        {

        }
    }
}