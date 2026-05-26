using Microsoft.EntityFrameworkCore;
using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
