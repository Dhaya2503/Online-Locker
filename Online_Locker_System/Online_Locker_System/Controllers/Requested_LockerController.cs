using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Locker_System.Models;

namespace Online_Locker_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Requested_LockerController : ControllerBase
    {
        private readonly LockerDbContext _context;

        public Requested_LockerController(LockerDbContext context)
        {
            _context = context;
        }

        // GET: api/Requested_Locker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requested_Locker>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requested_Locker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requested_Locker>> GetRequested_Locker(int id)
        {
            var requested_Locker = await _context.Requests.FindAsync(id);

            if (requested_Locker == null)
            {
                return NotFound();
            }

            return requested_Locker;
        }

        // PUT: api/Requested_Locker/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequested_Locker(int id, Requested_Locker requested_Locker)
        {
            if (id != requested_Locker.Request_Id)
            {
                return BadRequest();
            }

            _context.Entry(requested_Locker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Requested_LockerExists(id))
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

        // POST: api/Requested_Locker
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Requested_Locker>> PostRequested_Locker(Requested_Locker requested_Locker)
        {
            _context.Requests.Add(requested_Locker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequested_Locker", new { id = requested_Locker.Request_Id }, requested_Locker);
        }

        // DELETE: api/Requested_Locker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequested_Locker(int id)
        {
            var requested_Locker = await _context.Requests.FindAsync(id);
            if (requested_Locker == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(requested_Locker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Requested_LockerExists(int id)
        {
            return _context.Requests.Any(e => e.Request_Id == id);
        }
    }
}
