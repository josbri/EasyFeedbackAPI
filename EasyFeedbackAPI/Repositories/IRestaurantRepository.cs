using EasyFeedbackAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public interface IRestaurantRepository : IRepositoryBase<Restaurant>
    {
        public Task<Restaurant> FindById(int id);
    }
}
