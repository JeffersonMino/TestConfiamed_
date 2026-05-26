using Microsoft.AspNetCore.Mvc;
using UsuariosMG.Microservice.Interfaces;

namespace UsuariosMG.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _service;

        public UsuarioController(IUsuarioServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("{username}/stats")]
        public async Task<IActionResult> GetStats(string username)
        {
            var stats = await _service.GetStatsAsync(username);

            return Ok(stats);
        }
    }
}
