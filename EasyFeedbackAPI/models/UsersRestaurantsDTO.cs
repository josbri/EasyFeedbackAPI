using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class UsersRestaurantsDTO
    {
        public int UserID { get; set; }

        public int RestaurantID { get; set; }

        public UsersRestaurantsDTO(int userID, int restaurantID)
        {
            UserID = userID;
            RestaurantID = restaurantID;
        }

        public UsersRestaurantsDTO() { }
    }
}
