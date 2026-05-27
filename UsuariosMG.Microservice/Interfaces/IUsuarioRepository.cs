using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Interfaces
{
    /// <summary>
    /// Define operaciones de persistencia de usuarios.
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Agrega un nuevo usuario.
        /// </summary>
        Task AddAsync(Usuario user);
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        Task<List<Usuario>> GetAllAsync();

        Task<Usuario> GetByUsernameAsync(string username);
        /// <summary>
        /// Verifica si un usuario está saturado.
        /// </summary>
        Task<bool> IsUserSaturated(string username);
        /// <summary>
        /// Guarda cambios.
        /// </summary>
        Task SaveChangesAsync();
    }
}
