using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDA_tech_lab_2.Models
{
    public class SharedData
    {
        public static List<Person> Users { get; } = new List<Person>
        {
            new Person(){ Login = "user", Password = "user" },
            new Person(){ Login = "admin", Password = "admin" },
        };
    }
}
