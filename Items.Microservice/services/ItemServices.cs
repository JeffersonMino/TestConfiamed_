using Items.Microservice.Data;
using Items.Microservice.Dtos;
using Items.Microservice.Interfaces;
using Items.Microservice.Models;
using Microsoft.EntityFrameworkCore;
using static Items.Microservice.Models.Items;

namespace Items.Microservice.Services
{
    public class ItemServices : IItemServices
    {
        private readonly IItemRepository _repository;
        private readonly AppDbContext _context;

        public ItemServices(IItemRepository repository,
            AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task CreateAsync(CreateItemDto dto)
        {
            var users = await _context.Usuarios.ToListAsync();

            if (!users.Any())
            {
                throw new Exception("No hay usuarios disponibles");
            }

            string assignedUser = "";

            bool isUrgent = dto.DueDate <= DateTime.Now.AddDays(3);

            // Lista temporal de usuarios con menos tareas pendientes
            var userStats = new List<dynamic>();

            // recorremos los usuarios para obtener sus estadísticas de tareas
            foreach (var user in users)
            {
                var totalItems = await _context.Items
                    .CountAsync(x =>
                        x.AssignedUser == user.Username);

                var pendingItems = await _context.Items
                    .CountAsync(x =>
                        x.AssignedUser == user.Username &&
                        x.Status == Status.Pending);

                var highPriorityPending = await _context.Items
                    .CountAsync(x =>
                        x.AssignedUser == user.Username &&
                        x.Status == Status.Pending &&
                        x.Relevance == Relevance.High);

                userStats.Add(new
                {
                    Username = user.Username,
                    TotalItems = totalItems,
                    Pending = pendingItems,
                    HighPending = highPriorityPending
                });
            }
             

            // validamos las reglas 
            if (isUrgent)
            {
                assignedUser = userStats
                    .OrderBy(x => x.TotalItems)
                    .First()
                    .Username;
            }
            else if ((Relevance)dto.Relevance == Relevance.High)
            {
                assignedUser = userStats
                    .Where(x => x.HighPending <= 3)
                    .OrderBy(x => x.Pending)
                    .First()
                    .Username;
            }
            else
            {
                assignedUser = userStats
                    .OrderBy(x => x.Pending)
                    .First()
                    .Username;
            }

            var workItem = new Item
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Relevance = (Relevance)dto.Relevance,
                AssignedUser = assignedUser,
                Status = Status.Pending,
                CreatedAt = DateTime.Now
            };

            await _repository.AddAsync(workItem);

            await _repository.SaveChangesAsync();
        }
    }
}
