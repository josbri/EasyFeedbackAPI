using EasyFeedbackAPI.data;
using EasyFeedbackAPI.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(EasyFeedbackContext context) : base(context)
        {
        }
        public async Task<Restaurant> FindById(int id)
        {
            return await _context.Restaurants.Include(r => r.UsersRestaurants)
                .ThenInclude(ur => ur.User).AsNoTracking().FirstOrDefaultAsync(r => r.ID == id);
        }
    }
}
