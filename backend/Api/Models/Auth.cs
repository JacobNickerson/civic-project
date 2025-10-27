namespace Api.Models
{
    public class Auth
    {
        public int UserId { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        public DateTime LastLogin { get; set; }
        public int FailedAttempts { get; set; }
        public DateTime LockUntil { get; set; }

        public required User User { get; set; }
    }
}