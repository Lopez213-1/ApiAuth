using TaskApi.Models;

namespace TaskApi.Modesl
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public bool Completada { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}