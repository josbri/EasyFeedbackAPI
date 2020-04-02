using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class UserDTO
    {
        public string CognitoID { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public int RestaurantID { get; set; }

        public bool Admin { get; set; }

        public UserDTO(string cognitoID, string name, string surname, string email, int restaurantID, bool admin)
        {
            CognitoID = cognitoID;
            Name = name;
            Surname = surname;
            Email = email;
            RestaurantID = restaurantID;
            Admin = admin;
        }

        public UserDTO() { }
    }
}
