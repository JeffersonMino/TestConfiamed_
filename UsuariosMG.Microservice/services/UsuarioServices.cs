using Microsoft.EntityFrameworkCore;
using UsuariosMG.Microservice.Data;
using UsuariosMG.Microservice.Dtos;
using UsuariosMG.Microservice.Interfaces;
using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _repository;
        private readonly AppDbContext _context;

        public UsuarioServices(
            IUsuarioRepository repository,
            AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

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
    }
}
