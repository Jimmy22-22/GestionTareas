using GestionTareas.Application.Services;
using GestionTareas.Domain.Interfaces;
using GestionTareas.Infrastructure.Data;
using GestionTareas.Infrastructure.Repositories;
using ElectronNET.API;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas
{
    public class Program
    {
        public static async Task Main(string[] args)
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
            builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<TareaService>();
            builder.Services.AddScoped<ProyectoService>();

            builder.WebHost.UseElectron(args);

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

            if (HybridSupport.IsElectronActive)
            {
                await ElectronBootstrapAsync();
            }

            app.Run();
        }

        private static async Task ElectronBootstrapAsync()
        {
            var window = await Electron.WindowManager.CreateWindowAsync(new ElectronNET.API.Entities.BrowserWindowOptions
            {
                Width = 1200,
                Height = 800,
                Show = true,
                Frame = true,
                Title = "GestionTareas - Escritorio",
                AutoHideMenuBar = true
            });

            window.SetMenuBarVisibility(false);
            window.OnClosed += () => Electron.App.Exit();
        }
    }
}
