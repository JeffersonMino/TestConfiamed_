using Items.Microservice.Dtos;
using static Items.Microservice.Models.Items;

namespace Items.Microservice.Interfaces
{
    /// <summary>
    /// Servicio encargado de la lógica de negocio de ítems.
    /// </summary>
    public interface IItemServices
    {
        /// <summary>
        /// Crea un nuevo ítem de trabajo.
        /// </summary>
        Task CreateAsync(CreateItemDto dto);

        /// <summary>
        /// Obtiene todos los ítems.
        /// </summary>
        Task<IEnumerable<Item>> GetAllAsync();
    }
}
