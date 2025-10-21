namespace Api.Models
{
    public class Message
    {
        public int Id { get; set; }
        public required int ConversationId { get; set; }
        public required int SenderId { get; set; }
        public required string Content { get; set; }
        public string? AttachmentUrl { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
        public bool IsDeleted { get; set; }

        public required Conversation Conversation { get; set; }
        public required User User { get; set; }
    }
}