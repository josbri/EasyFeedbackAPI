using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyFeedbackAPI.data;
using EasyFeedbackAPI.models;

namespace EasyFeedbackAPI.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaitersController : ControllerBase
    {
        private readonly EasyFeedbackContext _context;

        private Waiter ToWaiter(WaiterDTO w)
        {
            return new Waiter { Name = w.Name, Surname = w.Surname, RestauranteID = w.RestauranteID };
        }
        public WaitersController(EasyFeedbackContext context)
        {
            _context = context;
        }

        // GET: api/Waiters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Waiter>>> GetWaiters()
        {
            return await _context.Waiters.ToListAsync();
        }

        // GET: api/Waiters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Waiter>> GetWaiter(int id)
        {
            var waiter = await _context.Waiters.FindAsync(id);

            if (waiter == null)
            {
                return NotFound();
            }

            return waiter;
        }

        // PUT: api/Waiters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaiter(int id, Waiter waiter)
        {
            if (id != waiter.ID)
            {
                return BadRequest();
            }

            _context.Entry(waiter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaiterExists(id))
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

        // POST: api/Waiters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Waiter>> PostWaiter(WaiterDTO waiterDTO)
        {
            var waiter = ToWaiter(waiterDTO);

            _context.Waiters.Add(waiter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaiter", new { id = waiter.ID }, waiterDTO);
        }

        // DELETE: api/Waiters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Waiter>> DeleteWaiter(int id)
        {
            var waiter = await _context.Waiters.FindAsync(id);
            if (waiter == null)
            {
                return NotFound();
            }

            _context.Waiters.Remove(waiter);
            await _context.SaveChangesAsync();

            return waiter;
        }

        private bool WaiterExists(int id)
        {
            return _context.Waiters.Any(e => e.ID == id);
        }
    }
}
