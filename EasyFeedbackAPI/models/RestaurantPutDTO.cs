using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class RestaurantPutDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Logo { get; set; }
        public int Tables { get; set; }

        public string Abrev { get; set; }

        public int LicencesUsed { get; set; }

        public int LicensesLeft { get; set; }
        public int ReturnCode { get; set; }

        public RestaurantPutDTO() { }
    }
}
