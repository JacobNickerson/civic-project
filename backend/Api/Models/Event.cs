namespace Api.Models
{
    public enum EventVisibility
    {
        Private = 0,
        FriendsOnly = 1,
        Public = 2
    }
    public class Event
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required EventVisibility Visibility { get; set; } 

        public required User Author { get; set; }
        public List<EventFollow> Followers { get; set; } = new();
    }
}