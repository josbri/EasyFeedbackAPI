using System;
using System.ComponentModel.DataAnnotations;

namespace EasyFeedbackAPI.models
{
    public class Comment
    {
#nullable enable
        public int ID { get; set; }

        public DateTime Date { get; set; } = new DateTime();

        public int RatingFood { get; set; }

        public int RatingService { get; set; }

        public string Text { get; set; }

        public Waiter? Waiter { get; set; }

        public Table? Table { get; set; }

#nullable disable
        public Comment()
        {
        }
    }
}
