using API.Models;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI;
namespace API.Controllers
{
    public class StudentController : ApiController
    {
        public void insertStudentData(Student student)
        {
            try
            {
                HttpRequestMessage request = this.Request;
                if (!request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads");
                var provider = new MultipartFormDataStreamProvider(root);

                var task = request.Content.ReadAsMultipartAsync(provider).
                    ContinueWith<HttpResponseMessage>(o =>
                    {
                        //string file1 = provider.BodyPartFileNames.First().Value;
                        // this is the file name on the server where the file was saved 

            return new HttpResponseMessage()
                        {
                            Content = new StringContent("File uploaded.")
                        };
                    }
                );

                SqlConnection con = new SqlConnection( Connection.conStr);
                Connection.openCon(ref con);
                string q = "insert into STUDENT(FIRSTNAME,LASTNAME,ADDRESS,PHONENO,IMAGEPATH,EMAIL,PARENT)" +
                    "values('"+student.firstname+"','"+student.lastname+"','"+student.address+"'," +
                    "'"+student.phonenumber+"','"+student.image+"','"+student.email+"','"+student.parent+"')";
                SqlCommand cmd = new SqlCommand(q,con);
                int result=cmd.ExecuteNonQuery();
                if (result>0)
                {
                    Redirect("http://localhost:59253/Students/Index");
                }
                Connection.closeCon(ref con);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}