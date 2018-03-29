using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class loginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class tbl
    {
        public DataTable table { get; set; }
    }
}