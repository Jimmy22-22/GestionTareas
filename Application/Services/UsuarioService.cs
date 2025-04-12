using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces;

namespace GestionTareas.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Usuario>> ObtenerTodos() => _repo.GetAllAsync();
        public Task<Usuario?> ObtenerPorId(int id) => _repo.GetByIdAsync(id);
        public Task Crear(Usuario usuario) => _repo.AddAsync(usuario);
        public Task Editar(Usuario usuario) => _repo.UpdateAsync(usuario);
        public Task Eliminar(int id) => _repo.DeleteAsync(id);
    }
}
