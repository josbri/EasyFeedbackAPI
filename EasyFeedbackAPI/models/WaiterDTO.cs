using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class WaiterDTO
    {
#nullable enable

        public string Name { get; set; }
        public string Surname { get; set; } = "";
        public int RestauranteID { get; set; }

        public WaiterDTO(string name, string surname, int restaurante)
        {
            Name = name;
            Surname = surname;
            RestauranteID = restaurante;
        }

        public WaiterDTO() { }
#nullable disable
    }
}
