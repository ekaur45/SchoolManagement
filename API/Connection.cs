using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API
{
    public class Connection
    {
       
        public static string conStr="Data Source=NOUMAN_YASEEN;Initial Catalog=dev-test-db;Integrated Security=True";
       
        public static void openCon(ref SqlConnection con)
        {
            try
            {
                if (con.State== ConnectionState.Closed)
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
}