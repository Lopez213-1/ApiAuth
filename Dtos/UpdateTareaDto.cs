namespace TaskApi.Dtos
{
    public class UpdateTareaDto
    {
        public string Titulo { get; set; } = string.Empty;
        public bool Completada { get; set; }
    }
}