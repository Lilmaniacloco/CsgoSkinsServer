using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using data;

namespace csgoSkins.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassangersController : ControllerBase
    {
        private readonly AirlineContext _context;

        public PassangersController(AirlineContext context)
        {
            _context = context;
        }

        // GET: api/Passangers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passanger>>> GetPassangers()
        {
            return await _context.Passangers.ToListAsync();
        }

        // GET: api/Passangers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passanger>> GetPassanger(int id)
        {
            var passanger = await _context.Passangers.FindAsync(id);

            if (passanger == null)
            {
                return NotFound();
            }

            return passanger;
        }

        // PUT: api/Passangers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassanger(int id, Passanger passanger)
        {
            if (id != passanger.Id)
            {
                return BadRequest();
            }

            _context.Entry(passanger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassangerExists(id))
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

        // POST: api/Passangers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passanger>> PostPassanger(Passanger passanger)
        {
            _context.Passangers.Add(passanger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassanger", new { id = passanger.Id }, passanger);
        }

        // DELETE: api/Passangers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassanger(int id)
        {
            var passanger = await _context.Passangers.FindAsync(id);
            if (passanger == null)
            {
                return NotFound();
            }

            _context.Passangers.Remove(passanger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassangerExists(int id)
        {
            return _context.Passangers.Any(e => e.Id == id);
        }
    }
}
