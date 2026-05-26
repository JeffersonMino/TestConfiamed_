using static Items.Microservice.Models.Items;

namespace Items.Microservice.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();

        Task AddAsync(Item workItem);

        Task SaveChangesAsync();
    }
}
