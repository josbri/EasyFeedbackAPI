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

        public string Autor { get; set; }
        public int ServicioID { get; set; }

        public CommentDTO(int ratingFood, int ratingService, string text, int servicio, string autor)
        {
            RatingFood = ratingFood;
            RatingService = ratingService;
            Text = text;
            ServicioID = servicio;
            Autor = autor;
        }

        public CommentDTO() { }
#nullable disable
    }
}
