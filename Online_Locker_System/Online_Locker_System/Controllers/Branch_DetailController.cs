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
    public class Branch_DetailController : ControllerBase
    {
        private readonly LockerDbContext _context;

        public Branch_DetailController(LockerDbContext context)
        {
            _context = context;
        }

        // GET: api/Branch_Detail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch_Detail>>> GetBranchs()
        {
            return await _context.Branchs.ToListAsync();
        }

        // GET: api/Branch_Detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branch_Detail>> GetBranch_Detail(int id)
        {
            var branch_Detail = await _context.Branchs.FindAsync(id);

            if (branch_Detail == null)
            {
                return NotFound();
            }

            return branch_Detail;
        }

        // PUT: api/Branch_Detail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch_Detail(int id, Branch_Detail branch_Detail)
        {
            if (id != branch_Detail.Branch_Id)
            {
                return BadRequest();
            }

            _context.Entry(branch_Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Branch_DetailExists(id))
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

        // POST: api/Branch_Detail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Branch_Detail>> PostBranch_Detail(Branch_Detail branch_Detail)
        {
            _context.Branchs.Add(branch_Detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranch_Detail", new { id = branch_Detail.Branch_Id }, branch_Detail);
        }

        // DELETE: api/Branch_Detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch_Detail(int id)
        {
            var branch_Detail = await _context.Branchs.FindAsync(id);
            if (branch_Detail == null)
            {
                return NotFound();
            }

            _context.Branchs.Remove(branch_Detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Branch_DetailExists(int id)
        {
            return _context.Branchs.Any(e => e.Branch_Id == id);
        }
    }
}
