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
        public string? Surname { get; set; }

        public WaiterDTO(string name, string? surname)
        {
            Name = name;
            Surname = surname;
        }


#nullable disable
    }
}
