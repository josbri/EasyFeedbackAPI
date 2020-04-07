using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class Servicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int MesaID { get; set; }
        public int RestauranteID { get; set; }
        public Restaurant Restaurant { get; set; }
        public int Comensales { get; set; }
        public double AverageFood { get; set; }
        public double AverageService { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comentarios { get; set; }

        public Servicio(int iD, DateTime date, int mesaID, int restauranteID, int comensales, double averageFood, double averageService)
        {
            ID = iD;
            Date = date;
            MesaID= mesaID;
            RestauranteID = restauranteID;
            Comensales = comensales;
            AverageFood = averageFood;
            AverageService = averageService;
        }

        public Servicio()
        {
        }
    }
}
