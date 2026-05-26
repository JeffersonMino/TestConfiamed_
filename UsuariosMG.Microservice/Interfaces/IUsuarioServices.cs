using UsuariosMG.Microservice.Dtos;
using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Interfaces
{
    public interface IUsuarioServices
    {
        Task<List<Usuario>> GetAllAsync();

        Task<UserDto> GetStatsAsync(string username);
    }
}
