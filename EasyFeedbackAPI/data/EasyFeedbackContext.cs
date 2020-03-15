using System;
using EasyFeedbackAPI.models;
using Microsoft.EntityFrameworkCore;

namespace EasyFeedbackAPI.data
{
    public class EasyFeedbackContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Chef> Chefs { get; set; }

    }
}
