using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDA_tech_lab_2.Models
{
    public class Plant 
    {
        static int MaxId = 0;
        public int id { get; private set; }
        
        [BindRequired] public string Name { get; private set; }
        public float Capacity { get; private set; }
        public int Year { get; private set; }
        public string Country { get; private set; }
        public HashSet<int> OwnerIds { get; private set; }//гарантирует, что один владелец не появится дважды
        public Plant (): this("new_plant")
        {
        }
        public Plant(string name, float capacity=0, int year=0, string country = "unknown", HashSet<int> ownerids = null)
        {
            id = MaxId++;
            Name = name;
            Capacity = capacity;
            Year = year;
            Country = country;
            OwnerIds = ownerids?? new HashSet<int>();
        }
        //public Plant(string name, float capacity, int year, string country)
        //{
        //    id = MaxId++;
        //    Name = name;
        //    Capacity = capacity;
        //    Year = year;
        //    Country = country;
        //    OwnerIds = new List<int>();
        //}
        //public Plant(string name)
        //{
        //    id = MaxId++;
        //    Name = name;
        //    Capacity = 0.0f;
        //    Year = 0;
        //    Country = "unknown";
        //    OwnerIds = new List<int>();
        //}
        public void AddPOwner(int id) => OwnerIds.Add(id); //?????
        //public string AddPlant(Plant new_plant);

        public void ChengeCapacity(float newCapacity)
        {
            Capacity = newCapacity;
        }

        /*public List<string> CollectOwners()
        {
            List<string> OwnerNames = new List<string>;
            while (OwnerIds != null)
            {
                Owner owner = new Owner();
                OwnerNames.Add() //how to add owners here <------------------------------------
            }
            return OwnerNames;
        }*/

        public void ExtraDetails(float newCapacity, int newYear, string newName)
        {
            Capacity = newCapacity;
            Name = newName;
            Year = newYear;
        }
    }
}
