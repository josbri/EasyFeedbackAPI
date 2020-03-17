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
    public class ChefsController : ControllerBase
    {
        private readonly EasyFeedbackContext _context;

        private Chef ToChef(ChefDTO c)
        {
            return new Chef { Name = c.Name, Surname = c.Surname };
        }
        public ChefsController(EasyFeedbackContext context)
        {
            _context = context;
        }

        // GET: api/Chefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chef>>> GetChefs()
        {
            return await _context.Chefs.ToListAsync();
        }

        // GET: api/Chefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chef>> GetChef(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);

            if (chef == null)
            {
                return NotFound();
            }

            return chef;
        }

        // PUT: api/Chefs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChef(int id, Chef chef)
        {
            if (id != chef.ID)
            {
                return BadRequest();
            }

            _context.Entry(chef).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChefExists(id))
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

        // POST: api/Chefs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Chef>> PostChef(ChefDTO chefDTO)
        {
            var chef = ToChef(chefDTO);

            _context.Chefs.Add(chef);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChef", new { id = chef.ID }, chef);
        }

        // DELETE: api/Chefs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chef>> DeleteChef(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);
            if (chef == null)
            {
                return NotFound();
            }

            _context.Chefs.Remove(chef);
            await _context.SaveChangesAsync();

            return chef;
        }

        private bool ChefExists(int id)
        {
            return _context.Chefs.Any(e => e.ID == id);
        }
    }
}
