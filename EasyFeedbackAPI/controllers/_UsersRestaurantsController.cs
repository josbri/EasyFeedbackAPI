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
    public class _UsersRestaurantsController : ControllerBase
    {
        private readonly EasyFeedbackContext _context;

        private UsersRestaurants ToUsersRestaurants(UsersRestaurantsDTO u)
        {
            return new UsersRestaurants { RestaurantID = u.RestaurantID, UserID = u.UserID };
        }
        public _UsersRestaurantsController(EasyFeedbackContext context)
        {
            _context = context;
        }

        // GET: api/UsersRestaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersRestaurants>>> GetUsersRestaurants()
        {
            return await _context.UsersRestaurants.ToListAsync();
        }

        // GET: api/UsersRestaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersRestaurants>> GetUsersRestaurants(int id)
        {
            var usersRestaurants = await _context.UsersRestaurants.FindAsync(id);

            if (usersRestaurants == null)
            {
                return NotFound();
            }

            return usersRestaurants;
        }


        // PUT: api/UsersRestaurants/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersRestaurants(int id, UsersRestaurants usersRestaurants)
        {
            if (id != usersRestaurants.ID)
            {
                return BadRequest();
            }

            _context.Entry(usersRestaurants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersRestaurantsExists(id))
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

        // POST: api/UsersRestaurants
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UsersRestaurants>> PostUsersRestaurants(UsersRestaurantsDTO usersRestaurantsDTO)
        {
            var usersRestaurants = ToUsersRestaurants(usersRestaurantsDTO);
            _context.UsersRestaurants.Add(usersRestaurants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersRestaurants", new { id = usersRestaurants.ID }, usersRestaurants);
        }

        // DELETE: api/UsersRestaurants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersRestaurants>> DeleteUsersRestaurants(int id)
        {
            var usersRestaurants = await _context.UsersRestaurants.FindAsync(id);
            if (usersRestaurants == null)
            {
                return NotFound();
            }

            _context.UsersRestaurants.Remove(usersRestaurants);
            await _context.SaveChangesAsync();

            return usersRestaurants;
        }

        private bool UsersRestaurantsExists(int id)
        {
            return _context.UsersRestaurants.Any(e => e.ID == id);
        }
    }
}
