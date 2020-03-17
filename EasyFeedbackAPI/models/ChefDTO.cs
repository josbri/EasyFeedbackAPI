using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class ChefDTO
    {
#nullable enable
        public string Name { get; set; }
        public string? Surname { get; set; }

        public ChefDTO(string name, string? surname)
        {
            Name = name;
            Surname = surname;
        }

#nullable disable
    }
}
