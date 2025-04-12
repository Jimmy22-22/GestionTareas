using GestionTareas.Application.Services;
using GestionTareas.Domain.Interfaces;
using GestionTareas.Infrastructure.Data;
using GestionTareas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.RootDirectory = "/Presentation/Pages";
            });

            builder.Services.AddServerSideBlazor();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<ITareaRepository, TareaRepository>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<TareaService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapBlazorHub();

            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
