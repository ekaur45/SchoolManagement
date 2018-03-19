using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(loginModel login)
        {
            SqlConnection con = new SqlConnection(@"Data Source=ekaur45\sqlexpress;Initial Catalog=SchoolManagement;Integrated Security=True");
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Count(*) as COUNT FROM USERS WHERE [USERNAME]='"+login.username+"' AND [PASSWORD]='"+login.password+"' COLLATE SQL_Latin1_General_CP1_CS_AS AND ISNULL(DELETED,0)=0", con);
                DataTable dt = new DataTable("");
                sda.Fill(dt);
                if (dt.Rows[0]["COUNT"].ToString()=="1")
                {
                    Response.Redirect("/Home/Index");
                }                
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>"+ex.Message+"</script>");
            }
            Response.Write("<script>Login Error</script>");
            Response.Redirect("/Account/Index");
            return View();
        }
    }
}