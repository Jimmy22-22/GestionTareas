using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces;
using GestionTareas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infrastructure.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly AppDbContext _context;
        public TareaRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Tarea tarea)
        {
            _context.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Tarea>> GetAllAsync() =>
            _context.Tareas.Include(t => t.Usuario).ToListAsync();

        public Task<Tarea?> GetByIdAsync(int id) =>
            _context.Tareas.Include(t => t.Usuario).FirstOrDefaultAsync(t => t.Id == id);

        public async Task UpdateAsync(Tarea tarea)
        {
            _context.Update(tarea);
            await _context.SaveChangesAsync();
        }
    }
}
