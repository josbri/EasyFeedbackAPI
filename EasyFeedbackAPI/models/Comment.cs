using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFeedbackAPI.models
{
    public class Comment
    {
#nullable enable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int RatingFood { get; set; }

        public int RatingService { get; set; }

        public string Text { get; set; }

        public string Autor { get; set; }
        public int ServicioID { get; set; }
        public Servicio Servicio { get; set; }

        public Comment(int iD, DateTime date, int ratingFood, int ratingService, string text, string autor, int servicioID)
        {
            ID = iD;
            Date = DateTime.Now;
            RatingFood = ratingFood;
            RatingService = ratingService;
            Text = text;
            ServicioID = servicioID;
            Autor = autor;
        }





#nullable disable
        public Comment()
        {
        }
    }
}
