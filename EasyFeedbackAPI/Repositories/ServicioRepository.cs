using EasyFeedbackAPI.data;
using EasyFeedbackAPI.models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Servicio>> FindByRestaurantId(int id)
        {
            return await _context.Servicios.Include(s => s.Comentarios).Include(s => s.User)
               .AsNoTracking().Where(u => u.RestauranteID == id).ToListAsync();
        }
    }
}
