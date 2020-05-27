using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDA_tech_lab_2.Models
{
    public class Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Person(string login, string password, string role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
    }

}
