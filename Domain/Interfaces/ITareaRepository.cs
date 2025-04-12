using GestionTareas.Domain.Entities;

namespace GestionTareas.Domain.Interfaces
{
    public interface ITareaRepository
    {
        Task<List<Tarea>> GetAllAsync();
        Task<Tarea?> GetByIdAsync(int id);
        Task AddAsync(Tarea tarea);
        Task UpdateAsync(Tarea tarea);
        Task DeleteAsync(int id);
    }
}
