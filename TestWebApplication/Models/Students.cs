using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.Models
{
    public class Students
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime Enrolment_date { get; set; }
        public int Department_ID { get; set; }
    }
}