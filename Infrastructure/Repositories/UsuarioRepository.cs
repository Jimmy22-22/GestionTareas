using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces;
using GestionTareas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Usuario>> GetAllAsync() =>
            _context.Usuarios.Include(u => u.Tareas).ToListAsync();

        public Task<Usuario?> GetByIdAsync(int id) =>
            _context.Usuarios.Include(u => u.Tareas).FirstOrDefaultAsync(u => u.Id == id);

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
