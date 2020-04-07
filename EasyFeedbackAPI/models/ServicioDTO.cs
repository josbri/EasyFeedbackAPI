using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class ServicioDTO
    {

        public int MesaID { get; set; }

        public int Comensales { get; set; }

        public int RestauranteID { get; set; }

        public int UserID { get; set; }

        public ServicioDTO(int mesaID, int comensales, int restauranteID, int userID)
        {
            MesaID = mesaID;
            Comensales = comensales;
            RestauranteID = restauranteID;
            UserID = userID;
        }

        public ServicioDTO() { }
    }
}
