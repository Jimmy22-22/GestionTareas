Gestión de Tareas 
Objetivo
Este proyecto implementa una arquitectura basada en Clean Architecture con el fin de desarrollar una aplicación mantenible y escalable. El sistema permite gestionar tres entidades con operaciones CRUD completas: Usuarios, Tareas y Proyectos.

Tecnologías Usadas
- .NET 7.0
- Blazor Server
- Entity Framework Core
- SQL Server
- Bootstrap + íconos de Bootstrap
- Electron.NET 
Funcionalidades
- CRUD completo para:
  - Usuarios
  - Tareas
  - Proyectos
- Inyección de dependencias con interfaces
- Separación clara de responsabilidades
- Diseño visual moderno y responsivo
Instrucciones de Ejecución
1. Clonar el repositorio desde GitHub.
2. Crear la base de datos GestionTareasDb.
3. Configurar la cadena de conexión en appsettings.json.
4. Ejecutar el proyecto desde Visual Studio o desde CMD con el comando electronize start. 

Decisiones de Diseño
- Se eligió Blazor Server para una UI moderna en tiempo real.
- Se separaron los CRUD por entidad y acción (Create.razor, Edit.razor, etc.) para un mejor mantenimiento.
- Se aplicó el principio de inversión de dependencias usando interfaces (IUsuarioRepository, etc.).
- La UI fue estilizada completamente para mejorar la experiencia de usuario.

