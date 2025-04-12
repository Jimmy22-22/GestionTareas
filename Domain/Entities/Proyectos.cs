namespace GestionTareas.Domain.Entities
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; } = DateTime.Today;
        public DateTime? FechaFin { get; set; } 
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
