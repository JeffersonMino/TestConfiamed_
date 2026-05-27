using Microsoft.EntityFrameworkCore;
using UsuariosMG.Microservice.Data;
using UsuariosMG.Microservice.Dtos;
using UsuariosMG.Microservice.Interfaces;
using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Services
{
    /// <summary>
    /// Servicio encargado de la lógica de negocio de usuarios.
    /// </summary>
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _repository;
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor del servicio.
        /// </summary>
        public UsuarioServices(
            IUsuarioRepository repository,
            AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserDto> GetStatsAsync(string username)
        {
            var pending = await _context.Items
                .CountAsync(x =>
                    x.AssignedUser == username &&
                    x.Status == 1);

            var completed = await _context.Items
                .CountAsync(x =>
                    x.AssignedUser == username &&
                    x.Status == 2);

            var highPriority = await _context.Items
                .CountAsync(x =>
                    x.AssignedUser == username &&
                    x.Status == 1 &&
                    x.Relevance == 2);

            return new UserDto
            {
                NombreUsuario = username,
                ElementosPendientes = pending,
                ElementosCompletados = completed,
                PendientesAltaPrioridad = highPriority,
                EstaSaturado = highPriority > 3
            };
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="dto">Datos del usuario.</param>
        public async Task CreateAsync(Usuario dto)
        {
            var user = new Usuario
            {
                Username = dto.Username
            };

            await _repository.AddAsync(user);

            await _repository.SaveChangesAsync();
        }
        /// <summary>
        /// Determina si un usuario está saturado.
        /// </summary>
        /// <param name="username">Nombre del usuario.</param>
        public async Task<bool> IsUserSaturated(string username)
        {
            return await _repository.IsUserSaturated(username);
        }

    }
}
