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

        public int WaiterID { get; set; }

        public ServicioDTO(int mesaID, int comensales, int restauranteID, int waiterID)
        {
            MesaID = mesaID;
            Comensales = comensales;
            RestauranteID = restauranteID;
            WaiterID = waiterID;
        }

        public ServicioDTO() { }
    }
}
