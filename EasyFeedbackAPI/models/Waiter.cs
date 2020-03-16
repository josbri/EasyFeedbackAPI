using System;
namespace EasyFeedbackAPI.models
{
    public class Waiter
    {
        #nullable enable
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }


        #nullable disable
        public Waiter()
        {
        }
    }
}
