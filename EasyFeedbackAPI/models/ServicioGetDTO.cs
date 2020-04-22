using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class ServicioGetDTO
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int MesaID { get; set; }
        public int RestauranteID { get; set; }
        public int Comensales { get; set; }
        public double AverageFood { get; set; }
        public double AverageService { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
        public ICollection<CommentDTO> Comentarios { get; set; }

        public ServicioGetDTO()
        {
        }
    } 
}
