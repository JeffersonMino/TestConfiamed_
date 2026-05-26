using Microsoft.EntityFrameworkCore;
using UsuariosMG.Microservice.Data;
using UsuariosMG.Microservice.Interfaces;
using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByUsernameAsync(string username)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
