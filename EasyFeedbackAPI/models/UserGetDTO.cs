using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class UserGetDTO
    {
        public int ID { get; set; }

        public string CognitoID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Admin { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }

        public List<RestaurantGetDTO> Restaurants{ get; set;}

        public UserGetDTO() { }
    }


}
