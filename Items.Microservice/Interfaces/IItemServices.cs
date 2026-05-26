using Items.Microservice.Dtos;

namespace Items.Microservice.Interfaces
{
    public interface IItemServices
    {
        Task CreateAsync(CreateItemDto dto);
    }
}
