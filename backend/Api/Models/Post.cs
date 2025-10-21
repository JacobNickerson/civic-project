namespace Api.Models
{
    public class Post
    {
        public required int Id { get; set; }
        public required int UserId { get; set; }
        public required string Content { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required bool IsOfficial { get; set; }
        public required bool IsDeleted { get; set; }

        public required User Author { get; set; }
        public required List<PostReaction> Reactions { get; set; }
    }
}