using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        public class Student
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public int parent { get; set; }
            public string address { get; set; }
            public string phonenumber { get; set; }
            public IEnumerable<HttpPostedFileBase> files { get; set; }
            public string email { get; set; }
        }
        public class Connection
        {

            public static string conStr = "Data Source=NOUMAN_YASEEN;Initial Catalog=dev-test-db;Integrated Security=True";

            public static void openCon(ref SqlConnection con)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public static void closeCon(ref SqlConnection con)
            {
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpPost]
        public ActionResult insertStudent(Student student)
        {
            try
            {
                string path_file = "";
                foreach (var file in student.files)
                {
                    if (file.ContentLength>0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                        path_file = path + "";
                        file.SaveAs(path);
                    }
                }
                SqlConnection con = new SqlConnection(Connection.conStr);
                Connection.openCon(ref con);
                string q = "insert into STUDENT(FIRSTNAME,LASTNAME,ADDRESS,PHONENO,IMAGEPATH,EMAIL,PARENT)" +
                    "values('" + student.firstname + "','" + student.lastname + "','" + student.address + "'," +
                    "'" + student.phonenumber + "','" + path_file+"" + "','" + student.email + "','" + student.parent + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                int result = cmd.ExecuteNonQuery();
                
                Connection.closeCon(ref con);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Indexes(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Index");
        }
    }

}