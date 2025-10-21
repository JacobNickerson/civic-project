namespace Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public required Auth Auth { get; set; }
        public List<Message> Messages { get; set; } = new();
        public List<UserInConversation> Conversations { get; set; } = new();
        public List<Event> CreatedEvents { get; set; } = new();
        public List<EventFollow> FollowedEvents { get; set; } = new();
        public List<Post> Posts { get; set; } = new();
        public List<PostReaction> Reactions { get; set; } = new();
        public List<PetitionSignature> SignedPetitions { get; set; } = new();  
    }
}