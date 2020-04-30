using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDA_tech_lab_2.Models
{
    public class Owner
    {
        static int MaxId = 0; //one to the type
        public int id { get; private set; }
        public string Name { get; private set; }
        public List<int> plantIds { get; private set; }
        public Owner (string name)
        {
            id = MaxId++;
            Name = name;
            plantIds = new List<int>();
        }
        public Owner ()
        {
            id = MaxId++;
            Name = "unknown";
            plantIds = new List<int>();

        }
        public void AddPlant(int id) => plantIds.Add(id); //?????

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        
    }
}
