namespace Api.Models
{
    public class UserInConversation
    {
        public required int UserId { get; set; }
        public required int ConversationId { get; set; }
        public int? LastReadMessageId { get; set; }
        public DateTime JoinedAt { get; set; }

        public required User User { get; set; }
        public required Conversation Conversation { get; set; }
    }
}