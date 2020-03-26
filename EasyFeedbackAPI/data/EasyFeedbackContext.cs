using System;
using EasyFeedbackAPI.models;
using Microsoft.EntityFrameworkCore;

namespace EasyFeedbackAPI.data
{
    public class EasyFeedbackContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Waiter> Waiters { get; set; }

        public DbSet<Servicio> Servicios { get; set; }
        public EasyFeedbackContext(DbContextOptions<EasyFeedbackContext> options) : base(options)
        {
            
        }


        //Creamos un constructor que reciba DbContextOptions para que ASP.NET le inyecte la configuracion


    }
}
