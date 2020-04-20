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
        public string Location { get; set; }

        public string Logo { get; set; }

        public string Abrev { get; set; }
        public int Tables { get; set; }
        public int? LicencesUsed { get; set; }

        public int? LicensesLeft { get; set; }
        public int ReturnCode { get; set; }
        public RestaurantDTO(string name, string location, string logo, int numMesas, string abrev)
        {
            Name = name;
            Location = location;
            Logo = logo;
            Tables = numMesas;
            Abrev = abrev;
        }

        public RestaurantDTO() { }
#nullable disable
    }
}
