using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class UserInsideRestaurantDTO
    {
        public int ID { get; set; }
        public string CognitoID { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }

       // public int RestaurantID { get; set; }
        public bool Admin { get; set; }

        public UserInsideRestaurantDTO(int iD, string cognitoID, string name, string surname, string email, string username, bool admin)
        {
            ID = iD;
            CognitoID = cognitoID;
            Name = name;
            Surname = surname;
            Email = email;
            Username = username;
            Admin = admin;
        }

        public UserInsideRestaurantDTO() { }
    }
}
