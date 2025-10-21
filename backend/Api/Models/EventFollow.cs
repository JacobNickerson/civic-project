namespace Api.Models
{
    public class EventFollow
    {
        public required int UserId { get; set; }
        public required int EventId { get; set; }
        public required bool IsNotified { get; set; }

        public required User User { get; set; }
        public required Event Event { get; set; }
    }
}