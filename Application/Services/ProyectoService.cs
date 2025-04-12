using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces;

namespace GestionTareas.Application.Services
{
    public class ProyectoService
    {
        private readonly IProyectoRepository _repo;

        public ProyectoService(IProyectoRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Proyecto>> ObtenerTodos() => _repo.GetAllAsync();
        public Task<Proyecto?> ObtenerPorId(int id) => _repo.GetByIdAsync(id);
        public Task Crear(Proyecto proyecto) => _repo.AddAsync(proyecto);
        public Task Editar(Proyecto proyecto) => _repo.UpdateAsync(proyecto);
        public Task Eliminar(int id) => _repo.DeleteAsync(id);
    }
}
