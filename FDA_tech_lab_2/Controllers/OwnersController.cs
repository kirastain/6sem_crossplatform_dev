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
    public class OwnersController : ControllerBase
    {
        static List<Owner> owners = new List<Owner>
        {
            new Owner("Andeavor"),
            new Owner("LNDC"),
            new Owner("Shell"),
            new Owner("Mitsubishi")
        };
       
        private readonly TodoContext _context;

        public OwnersController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Owners
        [HttpGet]
        public IEnumerable<Owner> GetOwners()
        {
            return owners;
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> GetOwner(int id) //ActionResult is a type for a result from an action
        {
            var owner = owners.FirstOrDefault(i=>i.id==id);

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        // PUT: api/Owners/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(long id, Owner owner)
        {
            if (id != owner.id)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwner", new { id = owner.id }, owner);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Owner>> DeleteOwner(long id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return owner;
        }

        private bool OwnerExists(long id)
        {
            return _context.Owners.Any(e => e.id == id);
        }
    }
}
