using System;
namespace EasyFeedbackAPI.models
{
    public class Chef
    {
#nullable enable
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }

#nullable disable
        public Chef()
        {
        }
    }
}
