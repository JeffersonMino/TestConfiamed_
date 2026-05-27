using static Items.Microservice.Models.Items;

namespace Items.Microservice.Interfaces
{
    /// <summary>
    /// Define operaciones de persistencia de ítems.
    /// </summary>
    public interface IItemRepository
    {
        /// <summary>
        /// Obtiene todos los ítems.
        /// </summary>
        Task<List<Item>> GetAllAsync();
        /// <summary>
        /// Agrega un nuevo ítem.
        /// </summary>
        Task AddAsync(Item workItem);
        /// <summary>
        /// Guarda cambios.
        /// </summary>
        Task SaveChangesAsync();
    }
}
