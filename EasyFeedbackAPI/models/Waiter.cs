using System;
namespace EasyFeedbackAPI.models
{
    public class Waiter
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string? Apellidos { get; set; }

        public Waiter()
        {
        }
    }
}
