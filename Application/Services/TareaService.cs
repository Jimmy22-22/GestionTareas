using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces;

namespace GestionTareas.Application.Services
{
    public class TareaService
    {
        private readonly ITareaRepository _repo;

        public TareaService(ITareaRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Tarea>> ObtenerTodas() => _repo.GetAllAsync();
        public Task<Tarea?> ObtenerPorId(int id) => _repo.GetByIdAsync(id);
        public Task Crear(Tarea tarea) => _repo.AddAsync(tarea);
        public Task Editar(Tarea tarea) => _repo.UpdateAsync(tarea);
        public Task Eliminar(int id) => _repo.DeleteAsync(id);
    }
}
