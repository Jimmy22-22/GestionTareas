using GestionTareas.Domain.Entities;

namespace GestionTareas.Domain.Interfaces
{
    public interface IProyectoRepository
    {
        Task<List<Proyecto>> GetAllAsync();
        Task<Proyecto?> GetByIdAsync(int id);
        Task AddAsync(Proyecto proyecto);
        Task UpdateAsync(Proyecto proyecto);
        Task DeleteAsync(int id);
    }
}
