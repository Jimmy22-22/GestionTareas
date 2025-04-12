using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces;
using GestionTareas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infrastructure.Repositories
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly AppDbContext _context;
        public ProyectoRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Proyecto proyecto)
        {
            _context.Add(proyecto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _context.Remove(proyecto);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Proyecto>> GetAllAsync() =>
            _context.Proyectos.Include(p => p.Usuario).ToListAsync();

        public Task<Proyecto?> GetByIdAsync(int id) =>
            _context.Proyectos.Include(p => p.Usuario).FirstOrDefaultAsync(p => p.Id == id);

        public async Task UpdateAsync(Proyecto proyecto)
        {
            _context.Update(proyecto);
            await _context.SaveChangesAsync();
        }
    }
}
