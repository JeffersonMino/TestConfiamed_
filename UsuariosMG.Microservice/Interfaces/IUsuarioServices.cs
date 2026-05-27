using UsuariosMG.Microservice.Dtos;
using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Interfaces
{
    /// <summary>
    /// Define lógica de negocio para usuarios.
    /// </summary>
    public interface IUsuarioServices
    {
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        Task<List<Usuario>> GetAllAsync();

        Task<UserDto> GetStatsAsync(string username);
        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        Task CreateAsync(Usuario dto);

        /// <summary>
        /// Verifica si un usuario está saturado.
        /// </summary>
        Task<bool> IsUserSaturated(string username);
    }
}
