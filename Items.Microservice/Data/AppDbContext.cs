using Items.Microservice.Models;
using Microsoft.EntityFrameworkCore;
using static Items.Microservice.Models.Items;

namespace Items.Microservice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
