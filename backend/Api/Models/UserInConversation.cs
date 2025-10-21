namespace Api.Models
{
    public class UserInConversation
    {
        public int UserId { get; set; }
        public int ConversationId { get; set; }
        public int? LastReadMessageId { get; set; }
        public required DateTime JoinedAt { get; set; }

        public required User User { get; set; }
        public required Conversation Conversation { get; set; }
    }
}