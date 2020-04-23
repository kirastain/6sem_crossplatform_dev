using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDA_tech_lab_2.Models
{
    public class Database
    {
        List<Plant> plants { get; set; }
        List<Owner> owners { get; set; }

        /*public Database(List<Plant> plants, List<Owner> owners)
        {

            this.plants = plants; //start data here
            this.owners = owners; //dictionary!!!
        }*/
        public Database()
        {
            plants = new List<Plant>
            {
                new Plant("Kenai LNG", 1.5f, 1969, "USA"),
                new Plant("Marsa El Brega LNG", 3.2f, 1970, "Libya"),
                new Plant("Brunei LNG T1-4", 5.76f, 1973, "Brunei", new HashSet<int>(){2, 3, 4}),
                new Plant("Brunei LNG T5", 1.44f, 1974, "Brunei"),
                new Plant("ARDNOC LNG T1-2", 2.6f, 1977, "UAE"),
                new Plant("Arzew - GL1Z T1-6", 7.9f, 1978, "Algeria"),
                new Plant("Arzew - GL2Z T1-6", 8.2f, 1981, "Algeria"),
            };
            owners = new List<Owner>
            {
                new Owner("Andeavor"),
                new Owner("LNDC"),
                new Owner("Shell"),
                new Owner("Mitsubishi"),
                new Owner("Goverment of Brunei")
            };
        }

        //Get the data about the class requested
        public List<Plant> GetPlants()
        {
            return plants;
        }
        public List<Owner> GetOwners()
        {
            return owners;
        }

        //Add an element
        public void AddPlant(Plant NewPlant)
        {
            plants.Add(NewPlant);
        }
        public void AddOwner(Owner NewOwner)
        {
            owners.Add(NewOwner);
        }

        // search id here
        public List<string> GetOwnersByPlant(int PlantId)
        {
            var plant = plants.FirstOrDefault(p => p.id == PlantId);
            if (plant == null)
            {
                return null;
            }
            return plant.OwnerIds.Select(id => GetOwnerById(id)?.Name ?? "").ToList();
        }
        public Owner GetOwnerById(int owner_id)
        {
            var owner = owners.FirstOrDefault(p => p.id == owner_id);
            return owner;
        }
        public Plant GetPlantById(int plant_id) => plants.FirstOrDefault(p => p.id == plant_id);

        //adds an owner to the list
        public bool AddOwnerToPlant(int plantId, int ownerId)
        {
            var owner = GetOwnerById(ownerId);
            var plant = GetPlantById(plantId);

            if (plant == null || owner == null)
                return false;

            owner.AddPlant(plantId);
            plant.AddPOwner(ownerId);
            return true;

            //plants[id].OwnerIds.Add(OwnerId);//index != id (!)
       
            //return plants[plantId].OwnerIds.Contains(ownerId);

            //if (plants[id].OwnerIds.Contains(OwnerId))
            //    return true;
            //return false;
        }
    }

    
}
