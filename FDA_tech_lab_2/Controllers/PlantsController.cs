using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FDA_tech_lab_2.Models;

namespace FDA_tech_lab_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        static List<Plant> plants = new List<Plant>
        {
            new Plant("Kenai LNG", 1.5f, 1969, "USA"),
            new Plant("Marsa El Brega LNG", 3.2f, 1970, "Libya"),
            new Plant("Brunei LNG T1-4", 5.76f, 1973, "Brunei"),
            new Plant("Brunei LNG T5", 1.44f, 1974, "Brunei"),
            new Plant("ARDNOC LNG T1-2", 2.6f, 1977, "UAE"),
            new Plant("Arzew - GL1Z T1-6", 7.9f, 1978, "Algeria"),
            new Plant("Arzew - GL2Z T1-6", 8.2f, 1981, "Algeria"),
        };

        private readonly TodoContext _context;

        public PlantsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Plants
        [HttpGet]
        public IEnumerable<Plant> GetPlants()
        {
            return plants;
        }

        

        // GET: api/Plants/5
        [HttpGet("{id}")]
        public ActionResult<Plant> GetPlant(int id)
        {
            var plant = plants.FirstOrDefault(i => i.id == id);

            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        [HttpGet("{id}/owners")]
        public ActionResult<List<string>> GetPlantOwners(int id)
        {
            var plant = plants.FirstOrDefault(i => i.id == id);

            if (plant == null)
            {
                return NotFound();
            }

            List<string> OwnerNames = plant.CollectOwners(plant.OwnerIds);
            return OwnerNames;
        }

        [HttpPost]
        public string AddPlant([FromForm]Plant new_plant)
        {
            plants.Add(new_plant);
            return "Added";
        }

        [HttpPost("{id}/owner={OwnerId}")]
        public ActionResult<Plant> AddOwners(int id, int OwnerId)
        {
            if (plants[id].OwnerIds == null)
            {
                plants[id].AddPOwner(id)
            }

            plants[id].AddPOwner(OwnerId);
            return Ok(plants[id]);
        }

        // PUT: api/Plants/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlant(long id, Plant plant)
        {
            if (id != plant.id)
            {
                return BadRequest();
            }

            _context.Entry(plant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Plants
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /*[HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant plant)
        {
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlant", new { id = plant.id }, plant);
        }*/

        // DELETE: api/Plants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Plant>> DeletePlant(long id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

            return plant;
        }

        private bool PlantExists(long id)
        {
            return _context.Plants.Any(e => e.id == id);
        }
    }
}
