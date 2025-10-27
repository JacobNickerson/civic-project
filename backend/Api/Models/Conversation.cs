namespace Api.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<Message> Messages { get; set; } = new();
        public List<UserInConversation> Users { get; set; } = new();
    }
}