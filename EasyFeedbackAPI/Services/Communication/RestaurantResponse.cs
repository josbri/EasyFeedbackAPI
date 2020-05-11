using EasyFeedbackAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services.Communication
{
    public class RestaurantResponse : BaseResponse
    {
        public Restaurant Restaurant { get; private set; }

        public RestaurantResponse(bool success, string message, Restaurant restaurant) : base(success, message)
        {
            Restaurant = restaurant;
        }

        public RestaurantResponse(Restaurant restaurant) : this(true, string.Empty, restaurant)
        {
        }

        public RestaurantResponse(string message) : this(false, message, null) { }
    }
}
