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
    public class RestaurantsController : ControllerBase
    {
        private readonly EasyFeedbackContext _context;

        private Restaurant ToRestaurant(RestaurantDTO d)
        {
            return new Restaurant { Name = d.Name, Location = d.Location, Logo = d.Logo, Tables = d.Tables, Abrev = d.Abrev};
        }

        private RestaurantGetDTO ToRestaurantGetDTO (Restaurant r)
        {
            return new RestaurantGetDTO
            {
                ID = r.ID,
                Abrev = r.Abrev,
                Name = r.Name,
                Location = r.Location,
                Logo = r.Logo,
                Tables = r.Tables,
                LicencesUsed = r.LicencesUsed,
                LicensesLeft = r.LicensesLeft,
                ReturnCode = r.ReturnCode,
                Users = r.UsersRestaurants.Select(ur =>
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
            };

        }
        public RestaurantsController(EasyFeedbackContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            return await _context.Restaurants.ToListAsync();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantGetDTO>> GetRestaurant(int id)
        {
            var restaurantEntity = await _context.Restaurants
                .Include(i => i.UsersRestaurants)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(r => r.ID == id);

            if (restaurantEntity == null)
            {
                return NotFound();
            }

            var restaurantGetDTO = ToRestaurantGetDTO(restaurantEntity);



            return restaurantGetDTO;
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<RestaurantGetDTO>> PutRestaurant(int id, RestaurantPutDTO restaurantPutDTO)
        {
            try
            {
                if (id != restaurantPutDTO.ID)
                {
                    return BadRequest();
                }

                if (id == null)
                {
                    return BadRequest("Restaurant id is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Restaurant object");
                }

                var restaurantEntity = await _context.Restaurants
                    .Include(x=> x.UsersRestaurants)
                    .ThenInclude(i=>i.User)
                    .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();

                if (restaurantEntity == null)
                {
                    return NotFound();
                }

                restaurantEntity.LicencesUsed = restaurantPutDTO.LicencesUsed;
                restaurantEntity.LicensesLeft = restaurantPutDTO.LicensesLeft;
                restaurantEntity.Location = restaurantPutDTO.Location;
                restaurantEntity.Logo = restaurantPutDTO.Logo;
                restaurantEntity.Name = restaurantPutDTO.Name;
                restaurantEntity.ReturnCode = restaurantPutDTO.ReturnCode;
                restaurantEntity.Tables = restaurantPutDTO.Tables;


                _context.Entry(restaurantEntity).State = EntityState.Modified;

                    await _context.SaveChangesAsync();

                    var restaurantGetDTO = ToRestaurantGetDTO(restaurantEntity);
                    return restaurantGetDTO;
                
                             

            }
            catch (Exception e)
            {
                return NotFound();
            }
          
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(RestaurantDTO restaurantDTO)
        {
            var restaurant = ToRestaurant(restaurantDTO);
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetRestaurant", new { id = restaurant.ID }, restaurantDTO);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            return restaurant;
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.ID == id);
        }
    }
}
