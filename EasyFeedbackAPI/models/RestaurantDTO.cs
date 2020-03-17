using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class RestaurantDTO
    {
            
#nullable enable

        public string Name { get; set; }
        public string? Location { get; set; }

        public RestaurantDTO(string name, string? location)
        {
            Name = name;
            Location = location;
        }

#nullable disable
    }
}
