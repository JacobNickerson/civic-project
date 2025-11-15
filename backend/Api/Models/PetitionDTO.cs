namespace Api.Models
{
    public class PetitionDTO
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime? UpdatedAt { get; set; }
        public required string Author { get; set; }
    }
    public class CreatePetitionDTO
    {
        public int Id { get; set; }
        public required string Content { get; set; }
    }
    public class DeletePetitionDTO
    {
        public int Id { get; set; }
    }
}