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

        public Database(List<Plant> plants, List<Owner> owners)
        {
            this.plants = plants; //start data here
            this.owners = owners; //dictionary!!!
        }
        // search id here
        public List<string> GetOwners(int PlantId)
        {
            var plant = plants.FirstOrDefault(p => p.id == PlantId);
            if (plant == null)
            {
                return null;
            }
            return plant.OwnerIds.Select(id => GetOwnerById(id)).ToList();
        }
        public string GetOwnerById(int owner_id)
        {
            var owner = owners.FirstOrDefault(p => p.id == owner_id);
            return owner?.Name ?? "";
        }
    }

    
}
