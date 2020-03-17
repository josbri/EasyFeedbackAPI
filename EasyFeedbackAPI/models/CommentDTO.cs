using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class CommentDTO
    {
#nullable enable
        public int RatingFood { get; set; }

        public int RatingService { get; set; }

        public string Text { get; set; }

        public Waiter? Waiter { get; set; }

        public Table? Table { get; set; }

        public CommentDTO(int ratingFood, int ratingService, string text, Waiter? waiter, Table? table)
        {
            RatingFood = ratingFood;
            RatingService = ratingService;
            Text = text;
            Waiter = waiter;
            Table = table;
        }

#nullable disable
    }
}
