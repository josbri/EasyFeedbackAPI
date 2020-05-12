using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Services
{
    public interface IServicioService
    {
        Task<IEnumerable<Servicio>> FindByRestaurantIdAsync(int id);

        Task<ServicioResponse> CreateAsync(Servicio servicio);

        Task<ServicioResponse> UpdateAsync(int id, Servicio servicio);

        Task<ServicioResponse> DeleteAsync(int id);
    }
}
