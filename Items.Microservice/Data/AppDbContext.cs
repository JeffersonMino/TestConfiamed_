using Items.Microservice.Models;
using Microsoft.EntityFrameworkCore;
using static Items.Microservice.Models.Items;

namespace Items.Microservice.Data
{
    /// <summary>
    /// Contexto de base de datos principal.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor del contexto.
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Tabla de ítems.
        /// </summary>
        public DbSet<Item> Items { get; set; }
        /// <summary>
        /// Tabla de usuarios.
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
