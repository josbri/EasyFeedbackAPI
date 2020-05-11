using EasyFeedbackAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services.Communication
{
    public class ServicioResponse : BaseResponse
    {
        public Servicio Servicio { get; private set; }
        public ServicioResponse(bool success, string message, Servicio servicio) : base(success, message)
        {
            Servicio = servicio;
        }

        public ServicioResponse(Servicio servicio) : this(true, string.Empty, servicio) { }

        public ServicioResponse(string message) : this(false, message, null) { }

    }
}
