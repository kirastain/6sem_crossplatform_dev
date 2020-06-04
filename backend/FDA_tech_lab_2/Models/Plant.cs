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
        
        public string Name { get; set; }
        public float Capacity { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public List<int> OwnerIds { get; set; }
        public Plant ()//: this("new_plant")
        {
            id = MaxId++;
        }
        public Plant(string name, float capacity, int year, string country, List<int> ownerids)
        {
            id = MaxId++;
            Name = name;
            Capacity = capacity;
            Year = year;
            Country = country;
            OwnerIds = ownerids;
        }
        public Plant(string name, float capacity, int year, string country)
        {
            id = MaxId++;
            Name = name;
            Capacity = capacity;
            Year = year;
            Country = country;
            OwnerIds = new List<int>();
        }
        //{name: "ffffffff", capacity: 1111, year: 11111, country: "ggg"}
    public Plant(string name)
        {
            id = MaxId++;
            Name = name;
            Capacity = 0.0f;
            Year = 0;
            Country = "unknown";
            OwnerIds = new List<int>();
        }
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
