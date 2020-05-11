using EasyFeedbackAPI.data;
using EasyFeedbackAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public class ServicioRepository : RepositoryBase<Servicio>, IServicioRepository
    {
        public ServicioRepository(EasyFeedbackContext context) : base(context)
        {
        }
    }
}
