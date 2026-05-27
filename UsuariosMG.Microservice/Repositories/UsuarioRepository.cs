using Microsoft.EntityFrameworkCore;
using UsuariosMG.Microservice.Data;
using UsuariosMG.Microservice.Interfaces;
using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Repositories
{
    /// <summary>
    /// Repositorio encargado de persistencia de usuarios.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor del repositorio.
        /// </summary>
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByUsernameAsync(string username)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Username == username);
        }

        /// <summary>
        /// Agrega un nuevo usuario.
        /// </summary>
        public async Task AddAsync(Usuario user)
        {
            await _context.Usuarios.AddAsync(user);
        }

        /// <summary>
        /// Guarda cambios en base de datos.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica si un usuario está saturado.
        /// </summary>
        /// <param name="username">Nombre del usuario.</param>
        public async Task<bool> IsUserSaturated(string username)
        {
            var highPriorityCount = await _context.Items
                .CountAsync(x =>
                    x.AssignedUser == username);

            return highPriorityCount >= 3;
        }
    }
}
