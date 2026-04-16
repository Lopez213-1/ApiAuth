namespace TaskApi.Dtos
{
    public class GetAllDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public bool Completada { get; set; }
        public int UserId { get; set; }
    }
}