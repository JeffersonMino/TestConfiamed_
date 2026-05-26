using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();

        Task<Usuario> GetByUsernameAsync(string username);
    }
}
