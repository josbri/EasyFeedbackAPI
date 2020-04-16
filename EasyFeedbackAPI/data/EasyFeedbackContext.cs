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
        public DbSet<User> Users { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<UsersRestaurants> UsersRestaurants { get; set; }
        public EasyFeedbackContext(DbContextOptions<EasyFeedbackContext> options) : base(options)
        {
            
        }
        //Creamos un constructor que reciba DbContextOptions para que ASP.NET le inyecte la configuracion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User(1, "90df7e3b-5d67-4d86-a428-3392fc6638f8", "Josep", "Mira", "mira@mira.com", "mira", null, true));
        }
    }
}
