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
    public class Customer_DetailController : ControllerBase
    {
        private readonly LockerDbContext _context;

        public Customer_DetailController(LockerDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer_Detail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer_Detail>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customer_Detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer_Detail>> GetCustomer_Detail(int id)
        {
            var customer_Detail = await _context.Customers.FindAsync(id);

            if (customer_Detail == null)
            {
                return NotFound();
            }

            return customer_Detail;
        }

        // PUT: api/Customer_Detail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer_Detail(int id, Customer_Detail customer_Detail)
        {
            if (id != customer_Detail.User_Id)
            {
                return BadRequest();
            }

            _context.Entry(customer_Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_DetailExists(id))
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

        // POST: api/Customer_Detail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer_Detail>> PostCustomer_Detail(Customer_Detail customer_Detail)
        {
            _context.Customers.Add(customer_Detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer_Detail", new { id = customer_Detail.User_Id }, customer_Detail);
        }

        // DELETE: api/Customer_Detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer_Detail(int id)
        {
            var customer_Detail = await _context.Customers.FindAsync(id);
            if (customer_Detail == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer_Detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Customer_DetailExists(int id)
        {
            return _context.Customers.Any(e => e.User_Id == id);
        }
    }
}
