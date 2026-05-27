using Items.Microservice.Data;
using Items.Microservice.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Items.Microservice.Models.Items;

namespace Items.Microservice.Repositories
{
    /// <summary>
    /// Repositorio encargado de persistencia
    /// de ítems de trabajo.
    /// </summary>
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor del repositorio.
        /// </summary>
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los ítems.
        /// </summary>
        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }
        /// <summary>
        /// Agrega un nuevo ítem.
        /// </summary>
        public async Task AddAsync(Item workItem)
        {
            await _context.Items.AddAsync(workItem);
        }
        /// <summary>
        /// Guarda cambios en base de datos.
        /// </summary>

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
