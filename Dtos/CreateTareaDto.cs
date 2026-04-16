namespace TaskApi.Dtos
{
    public class CreateTareaDto
    {
        public string Titulo { get; set; } = string.Empty;
        public bool Completada { get; set; }
        public int UserId { get; set; }
    }
}