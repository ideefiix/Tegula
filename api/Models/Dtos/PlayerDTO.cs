namespace api.Models.Dtos
{
    public class PlayerDTO
    {
        public string Name { get; set; }

        public string? Color {get; set;}
        public DateTime? prevAttack {get; set;}
    }
}