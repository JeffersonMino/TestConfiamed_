using Items.Microservice.Dtos;
using Items.Microservice.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Items.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemServices _service;

        public ItemsController(IItemServices service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok("Tarea Creada");
        }
    }
}
