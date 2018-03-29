using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Http.Cors;
namespace API.Controllers
{
    [EnableCors(origins: "http://localhost:59253", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        [HttpGet, HttpPost]
        public string dd(string tbl)
        {
            try
            {
                string[] days = new string[] { "monday", "tuesday", "wednesday", "thurday", "friday", "satureday" };
                DataTable dt = new DataTable("TimeTable");
                dt.Columns.Add("CLASS_ID", typeof(string));
                dt.Columns.Add("ROOM_ID", typeof(string));
                dt.Columns.Add("DAY", typeof(string));
                dt.Columns.Add("STARTTIME", typeof(string));
                dt.Columns.Add("ENDTIME", typeof(string));
                dt.Columns.Add("SUBJECT_ID", typeof(string));
                dt.Columns.Add("DELETED", typeof(Boolean));
                string[] row = tbl.Split(';');
                for (int i = 0; i < row.Length - 1; i++)
                {
                    string[] cell = row[i].Split('%');
                    for (int j = 1; j < cell.Length - 1; j++)
                    {
                        dt.Rows.Add("1", "2", days[j - 1], cell[0].Split('-')[0], cell[0].Split('-')[1], cell[j], false);
                    }
                }
                SqlConnection con = new SqlConnection(@"Data Source=NOUMAN_YASEEN;Initial Catalog=DBACCESS.SchoolContext;Integrated Security=True");
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("PROC_TIMETABLE",con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add(new SqlParameter("@TBLTIME", dt));
                cmd.ExecuteNonQuery();
                if (con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                return "Record added successfully";
            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
