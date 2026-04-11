using TaskApi.Modesl;

namespace TaskApi.Models
{
    public class User
{
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Tarea> Tareas { get; set; } = new List<Tarea>();
        
    }
}