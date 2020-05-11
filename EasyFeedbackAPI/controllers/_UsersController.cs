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
    public class _UsersController : ControllerBase
    {
        private readonly EasyFeedbackContext _context;

        private User ToUser(UserDTO u)
        {
            return new User { Name = u.Name, Surname = u.Surname, 
                CognitoID = u.CognitoID, Admin = u.Admin, Email = u.Email, Username = u.Username};
        }
        public _UsersController(EasyFeedbackContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }


        // GET: api/Users
        [HttpGet("cognito/{cognito}")]
        public async Task<ActionResult<UserGetDTO>> GetByCognitoID(string CognitoID)
        {

            var user = await _context.Users
            .Include(i => i.UsersRestaurants)
            .ThenInclude(i => i.Restaurant)
            .Where(i => i.CognitoID == CognitoID)
            .Select(i => new UserGetDTO
            {
                ID = i.ID,
                Username = i.Username,
                CognitoID = i.CognitoID,
                Email = i.Email,
                Name = i.Name,
                Surname = i.Surname,
                Admin = i.Admin,
                Restaurants = i.UsersRestaurants.Select( ur => 
                new RestaurantGetDTO
                {
                    ID = ur.Restaurant.ID,
                    Abrev = ur.Restaurant.Abrev,
                    Name = ur.Restaurant.Name,
                    Location = ur.Restaurant.Location,
                    Logo = ur.Restaurant.Logo,
                    Tables = ur.Restaurant.Tables,
                    LicencesUsed = ur.Restaurant.LicencesUsed,
                    LicensesLeft = ur.Restaurant.LicensesLeft,
                    ReturnCode = ur.Restaurant.ReturnCode,
                    Users = ur.Restaurant.UsersRestaurants.Select (ur => 
                       new UserInsideRestaurantDTO
                       {
                           ID = ur.User.ID,
                           Admin = ur.User.Admin,
                           CognitoID = ur.User.CognitoID,
                           Email = ur.User.Email,
                           Name = ur.User.Name,
                           Username = ur.User.Username,
                           Surname = ur.User.Surname,
                       }).ToList()
                }
                    ).ToList()

            }).FirstOrDefaultAsync();


            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
        {
            var user = ToUser(userDTO);
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            var userRestaurant = new UsersRestaurants()
            {
                RestaurantID = userDTO.RestaurantID,
                UserID = user.ID
            };


            _context.UsersRestaurants.Add(userRestaurant);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
