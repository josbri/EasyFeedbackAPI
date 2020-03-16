using System;
using System.ComponentModel.DataAnnotations;

namespace EasyFeedbackAPI.models
{
    public class Restaurant
    {
#nullable enable
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }

#nullable disable
        public Restaurant()
        {
        }
    }
}
