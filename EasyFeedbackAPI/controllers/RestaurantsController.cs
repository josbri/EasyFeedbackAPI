using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFeedbackAPI.Extensions;
using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFeedbackAPI.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {

        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantsController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantGetDTO>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.FindByIdAsync(id);

            if(restaurant == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RestaurantGetDTO>(restaurant));
        }

        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RestaurantGetDTO>> PutRestaurant(int id, RestaurantPutDTO restaurantPutDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var restaurantEntity = _mapper.Map<Restaurant>(restaurantPutDTO);

            var result = await _restaurantService.UpdateAsync(id, restaurantEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<RestaurantGetDTO>(result.Restaurant));
        }

        // POST: api/Restaurants
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(RestaurantDTO restaurantDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var restaurantEntity = _mapper.Map<Restaurant>(restaurantDTO);

            var result = await _restaurantService.CreateAsync(restaurantEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<RestaurantGetDTO>(result.Restaurant));
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurant(int id)
        {
            var result = await _restaurantService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<RestaurantGetDTO>(result.Restaurant));
        }

    }
}