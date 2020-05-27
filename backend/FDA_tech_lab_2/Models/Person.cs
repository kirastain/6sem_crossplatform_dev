using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDA_tech_lab_2.Models
{
    public class Person
    {
        public string login { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public Person()
        {
            login = "admin";
            password = "12345";
            role = "admin";
        }

    }

}
