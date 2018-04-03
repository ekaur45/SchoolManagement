using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Student
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int parent { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public string image { get; set; }
        public string email { get; set; }
    }
}