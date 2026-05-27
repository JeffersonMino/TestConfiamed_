using Items.Microservice.Shared;
using Microsoft.AspNetCore.Mvc;
using UsuariosMG.Microservice.Dtos;
using UsuariosMG.Microservice.Interfaces;
using UsuariosMG.Microservice.Models;

namespace UsuariosMG.Microservice.Controllers
{
    /// <summary>
    /// Controlador encargado de la gestión de usuarios.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _service;

        /// <summary>
        /// Constructor del controlador.
        /// </summary>
        public UsuarioController(IUsuarioServices service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();

            return Ok(users);
        }

        /// <summary>
        /// Verifica si un usuario está saturado.
        /// </summary>
        /// <param name="username">Nombre del usuario.</param>
        [HttpGet("is-saturated/{username}")]
        public async Task<IActionResult> IsSaturated(string username)
        {
            var result = await _service.IsUserSaturated(username);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Estado del usuario",
                Data = null
            });
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="dto">Datos del usuario.</param>
        [HttpPost]
        public async Task<IActionResult> Create(Usuario dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "usuario creado correctamente",
                Data = null
            });
        }
    }
}
