using GestionTareas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GestionTareas.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Tarea> Tareas => Set<Tarea>();
        public DbSet<Proyecto> Proyectos => Set<Proyecto>();
    }
}
