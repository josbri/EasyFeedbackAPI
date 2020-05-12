using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Repositories;
using EasyFeedbackAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantService (IRestaurantRepository RestaurantRepository, IUnitOfWork unitOfWork)
        {
            _restaurantRepository = RestaurantRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<RestaurantResponse> CreateAsync(Restaurant Restaurant)
        {
            try
            {
                _restaurantRepository.Add(Restaurant);
                await _unitOfWork.CompleteAsync();

                return new RestaurantResponse(Restaurant);
            }
            catch (Exception ex)
            {
                return new RestaurantResponse($"There was an error creating the client: {ex.Message}");
            }
        }

        public async Task<RestaurantResponse> DeleteAsync(int id)
        {
            var existingRestaurant = await _restaurantRepository.FindFirstByConditionAsync(u => u.ID == id);

            if (existingRestaurant == null)
            {
                return new RestaurantResponse("Restaurant not found");
            }
            try
            {
                _restaurantRepository.Remove(existingRestaurant);
                await _unitOfWork.CompleteAsync();

                return new RestaurantResponse(existingRestaurant);
            }
            catch (Exception ex)
            {
                return new RestaurantResponse($"An error occurred when deleting the Restaurant: {ex.Message}");
            }
        }

        public async Task<Restaurant> FindByIdAsync(int id)
        {
            return await _restaurantRepository.FindById(id);
        }

        public async Task<RestaurantResponse> UpdateAsync(int id, Restaurant Restaurant)
        {
            var existingRestaurant = await _restaurantRepository.FindFirstByConditionAsync(u => u.ID == id);

            if (existingRestaurant == null)
            {
                return new RestaurantResponse("Restaurant not found");
            }

            existingRestaurant = Restaurant;

            try
            {
                _restaurantRepository.Update(existingRestaurant);
                await _unitOfWork.CompleteAsync();

                return new RestaurantResponse(existingRestaurant);
            }
            catch (Exception ex)
            {
                return new RestaurantResponse($"An error occurred when updating the Restaurant: {ex.Message}");
            }
        }
    }
}
