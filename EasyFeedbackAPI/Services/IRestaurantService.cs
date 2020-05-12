using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services
{
    public interface IRestaurantService
    {
        Task<Restaurant> FindByIdAsync(int id);

        Task<RestaurantResponse> CreateAsync(Restaurant restaurant);

        Task<RestaurantResponse> UpdateAsync(int id, Restaurant restaurant);

        Task<RestaurantResponse> DeleteAsync(int id);

    }
}
