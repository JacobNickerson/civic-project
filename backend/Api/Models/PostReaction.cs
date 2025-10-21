namespace Api.Models
{
    public class PostReaction
    {
        public required int UserId { get; set; }
        public required int PostId { get; set; }
        public required string ReactionType { get; set; }
        public required DateTime CreatedAt { get; set; }

        public required User Author { get; set; }
        public required Post Post { get; set; }
    }
}