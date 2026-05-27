using Items.Microservice.Dtos;
using Items.Microservice.Interfaces;
using Items.Microservice.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Items.Microservice.Controllers
{
    /// <summary>
    /// Controlador para la creacion y asignacion de tareas
    /// </summary>
    
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemServices _service;

        /// <summary>
        /// Constructor del controlador de ítems.
        /// </summary> 
        
        public ItemsController(IItemServices service)
        {
            _service = service;
        }

        /// <summary>
        /// Crea un nuevo ítem de trabajo.
        /// </summary>
        /// <param name="dto">Datos del ítem.</param> 
        /// 
        [HttpPost]
        public async Task<IActionResult> Create(CreateItemDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "tarea creada ok",
                Data = null
            });
        }
        /// <summary>
        /// Obtiene todos los ítems registrados.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();

            return Ok(items);
        }
    }
}
